#!groovy
node {
  def apps = [
    [name: "manage-material-api", port: '5000', exposed_port: '', path: 'api', domaine: "api.manage-material.dev-solus.com", domaine_prefix: ''],
    [name: "manage-material.", port: '4000', exposed_port: '', path: 'angular', domaine: "manage-material.dev-solus.com", domaine_prefix: ''],
  ];

  def app

  // stage('Initialize'){
  //     def dockerHome = tool 'myDocker'
  //     env.PATH = "${dockerHome}/bin:${env.PATH}"
  //   }

  stage('Cloning Git') {
    def commit = checkout scm
   
   def currentCommit = commit.GIT_COMMIT // sh(script: "git rev-parse HEAD", returnStdout: true).trim()
    def lastCommit = commit.GIT_PREVIOUS_SUCCESSFUL_COMMIT

    lastCommit = lastCommit == null || lastCommit.trim() == '' ? 'HEAD^' : lastCommit

    def command = "git diff-tree -r --name-only ${currentCommit} ${lastCommit}"

    // def changes0 = sh(script: command, returnStdout: true).trim()

    // println("----------------------------------> ${changes0}")

    apps.each { e ->

      if(!lastCommit) {
        echo "First commit building ${e.name} ..."
        return
      }

      def changes = sh(script: "${command} -- ./${e.name}", returnStdout: true).trim()

      println("***********************> ${changes}")

      // if (!changes) {
      //   echo "No changes in the folder ${e.name}."
      //   return
      // }

      // echo "Changes found in the folder ${e.name}:"
      // echo "${changes}"

      app = docker.build("${e.name}", "-t ${e.name} -f ./${e.path}/Dockerfile ./${e.path}")
      // sh """docker build -t sa-dev-api-cms -f ./cmsApi/Dockerfile ./"""

       script{
        try{
            sh "docker rm --force ${e.name}"
        }catch(Exception ex)
        {
          echo 'Exception occurred: ' + ex.toString()
        }
      }

      if (e.exposed_port == "") {
         sh """docker run -d \
          --restart unless-stopped \
          --network proxy \
          --volume /home/dev/volumes/${e.name}/wwwroot:/app/wwwroot \
          --volume /home/dev/volumes/${e.name}/db:/app/db \
          --label traefik.enable=true \
          --label traefik.http.routers.${e.name}.tls=true \
          --label traefik.http.routers.${e.name}.tls.certresolver=letsencrypt \
          --label traefik.http.routers.${e.name}.rule='Host(`${e.domaine}`) '\
          --label traefik.http.services.${e.name}.loadbalancer.server.port=${e.port} \
          --name ${e.name} \
          ${e.name}"""
      } else {
         sh """docker run -d \
          --restart unless-stopped \
          --publish ${e.exposed_port}:${e.port} \
          --volume /home/dev/volumes/${e.name}/wwwroot:/app/wwwroot \
          --name ${e.name} \
          ${e.name}"""
      }

      sh "docker rmi --force ${e.name}"
    }
  }
}
