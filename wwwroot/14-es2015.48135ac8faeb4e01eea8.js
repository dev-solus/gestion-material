(window.webpackJsonp=window.webpackJsonp||[]).push([[14],{Iyx2:function(e,t,i){"use strict";i.r(t),i.d(t,"EmplacementModule",(function(){return Y}));var c=i("ofXK"),n=i("tyNb"),a=i("mrSG"),o=i("fXoL"),s=i("VRyK"),r=i("3Pt+"),l=i("0IaG"),d=i("V2kc"),b=i("7q3A"),m=i("/t3+"),u=i("f0Cb"),p=i("kmnG"),h=i("qFsG"),f=i("d3UM"),g=i("bTqV"),C=i("FKr1");function V(e,t){if(1&e&&(o.Vb(0,"mat-option",14),o.Cc(1),o.Ub()),2&e){const e=t.$implicit;o.nc("value",e.id),o.Cb(1),o.Dc(e.nom)}}let U=(()=>{class e{constructor(e,t,i,c){this.dialogRef=e,this.data=t,this.fb=i,this.uow=c,this.subs=[],this.title="",this.departements=this.uow.departements.get(),this.folderToSaveInServer="emplacements"}ngOnInit(){this.o=this.data.model,this.title=this.data.title,this.createForm(),setTimeout(()=>{},100)}onNoClick(){this.dialogRef.close()}onOkClick(e){let t=null;t=0===e.id?this.uow.emplacements.post(e).subscribe(t=>{this.dialogRef.close(e)}):this.uow.emplacements.put(e.id,e).subscribe(t=>{this.dialogRef.close(e)}),this.subs.push(t)}createForm(){this.myForm=this.fb.group({id:[this.o.id,[r.q.required]],codeEmplacement:[this.o.codeEmplacement,[r.q.required]],description:[this.o.description,[r.q.required]],idDepartement:[this.o.idDepartement,[r.q.required]]})}resetForm(){this.o=new d.f,this.createForm()}ngOnDestroy(){this.subs.forEach(e=>{e.unsubscribe()})}}return e.\u0275fac=function(t){return new(t||e)(o.Pb(l.g),o.Pb(l.a),o.Pb(r.c),o.Pb(b.a))},e.\u0275cmp=o.Jb({type:e,selectors:[["app-update"]],decls:28,vars:6,consts:[[1,"dialog"],["mat-dialog-title",""],["role","toolbar",1,"task-header"],[1,"content"],[3,"formGroup"],["appearance","fill",1,"col-md-6"],["matInput","","formControlName","codeEmplacement","required",""],["appearance","fill",1,"col-md-12"],["matInput","","rows","6","formControlName","description","required",""],["formControlName","idDepartement","readonly",""],[3,"value",4,"ngFor","ngForOf"],["align","end"],["mat-button","","type","button",3,"click"],["mat-raised-button","","color","primary","cdkFocusInitial","",3,"disabled","click"],[3,"value"]],template:function(e,t){1&e&&(o.Vb(0,"div",0),o.Vb(1,"h1",1),o.Vb(2,"mat-toolbar",2),o.Vb(3,"span"),o.Cc(4),o.Ub(),o.Ub(),o.Qb(5,"mat-divider"),o.Ub(),o.Vb(6,"div",3),o.Vb(7,"mat-dialog-content"),o.Vb(8,"form",4),o.Vb(9,"mat-form-field",5),o.Vb(10,"mat-label"),o.Cc(11,"codeEmplacement"),o.Ub(),o.Qb(12,"input",6),o.Ub(),o.Vb(13,"mat-form-field",7),o.Vb(14,"mat-label"),o.Cc(15,"description"),o.Ub(),o.Qb(16,"textarea",8),o.Ub(),o.Vb(17,"mat-form-field",5),o.Vb(18,"mat-label"),o.Cc(19,"departements"),o.Ub(),o.Vb(20,"mat-select",9),o.Bc(21,V,2,2,"mat-option",10),o.ic(22,"async"),o.Ub(),o.Ub(),o.Ub(),o.Ub(),o.Vb(23,"mat-dialog-actions",11),o.Vb(24,"button",12),o.dc("click",(function(){return t.onNoClick()})),o.Cc(25,"Annuler"),o.Ub(),o.Vb(26,"button",13),o.dc("click",(function(){return t.onOkClick(t.myForm.value)})),o.Cc(27,"Enregistre"),o.Ub(),o.Ub(),o.Ub(),o.Ub()),2&e&&(o.Cb(4),o.Dc(t.title),o.Cb(4),o.nc("formGroup",t.myForm),o.Cb(13),o.nc("ngForOf",o.jc(22,4,t.departements)),o.Cb(5),o.nc("disabled",t.myForm.invalid))},directives:[l.h,m.a,u.a,l.e,r.r,r.m,r.g,p.c,p.f,h.b,r.b,r.l,r.f,r.p,f.a,c.k,l.c,g.a,C.n],pipes:[c.b],styles:[""]}),e})();var w=i("M9IT"),v=i("Dh3D"),k=i("JX91"),x=i("qQ+2"),y=i("hUFt"),D=i("bwXy"),S=i("NFeN"),E=i("7EHt"),L=i("+0xr"),R=i("Xa2L"),F=i("bSwM");function O(e,t){if(1&e&&(o.Vb(0,"mat-option",30),o.Cc(1),o.Ub()),2&e){const e=t.$implicit;o.nc("value",e.id),o.Cb(1),o.Dc(e.nom)}}function I(e,t){1&e&&o.Qb(0,"mat-spinner")}function B(e,t){if(1&e&&(o.Vb(0,"div",31),o.Bc(1,I,1,0,"mat-spinner",32),o.Ub()),2&e){const e=o.hc();o.Cb(1),o.nc("ngIf",e.isLoadingResults)}}function P(e,t){if(1&e){const e=o.Wb();o.Vb(0,"th",33),o.Vb(1,"mat-checkbox",34),o.dc("change",(function(t){o.uc(e);const i=o.hc();return t?i.masterToggle():null})),o.Ub(),o.Ub()}if(2&e){const e=o.hc();o.Cb(1),o.nc("checked",0!==e.selectedList.length&&e.isAllSelected())("indeterminate",0!==e.selectedList.length&&!e.isAllSelected())}}function q(e,t){if(1&e){const e=o.Wb();o.Vb(0,"td",35),o.Vb(1,"mat-checkbox",36),o.dc("click",(function(t){return o.uc(e),t.stopPropagation()}))("change",(function(i){o.uc(e);const c=t.$implicit,n=o.hc();return i?n.check(c):null})),o.Ub(),o.Ub()}if(2&e){const e=t.$implicit,i=o.hc();o.Cb(1),o.nc("checked",i.isSelected(e))}}function Q(e,t){1&e&&(o.Vb(0,"th",37),o.Cc(1,"Code Emplacement"),o.Ub())}function j(e,t){if(1&e&&(o.Vb(0,"td",35),o.Cc(1),o.Ub()),2&e){const e=t.$implicit;o.Cb(1),o.Dc(e.codeEmplacement)}}function T(e,t){1&e&&(o.Vb(0,"th",33),o.Cc(1,"Departement"),o.Ub())}function A(e,t){if(1&e&&(o.Vb(0,"td",35),o.Cc(1),o.Ub()),2&e){const e=t.$implicit;o.Cb(1),o.Dc(e.departement)}}function z(e,t){if(1&e){const e=o.Wb();o.Vb(0,"th",33),o.Vb(1,"button",38),o.dc("click",(function(){return o.uc(e),o.hc().deleteList()})),o.Vb(2,"mat-icon"),o.Cc(3,"delete_sweep"),o.Ub(),o.Ub(),o.Ub()}if(2&e){const e=o.hc();o.Cb(1),o.nc("disabled",0===e.selectedList.length)}}function N(e,t){if(1&e){const e=o.Wb();o.Vb(0,"td",35),o.Vb(1,"div",39),o.Vb(2,"button",40),o.dc("click",(function(){o.uc(e);const i=t.$implicit;return o.hc().edit(i)})),o.Vb(3,"mat-icon"),o.Cc(4,"create"),o.Ub(),o.Ub(),o.Vb(5,"button",41),o.dc("click",(function(){o.uc(e);const i=t.$implicit;return o.hc().delete(i.id)})),o.Vb(6,"mat-icon"),o.Cc(7,"delete_sweep"),o.Ub(),o.Ub(),o.Ub(),o.Ub()}}function $(e,t){1&e&&o.Qb(0,"tr",42)}function M(e,t){1&e&&o.Qb(0,"tr",43)}const G=function(){return[10,25,50,100,250]},_=[{path:"",redirectTo:"list",pathMatch:"full"},{path:"list",component:(()=>{class e{constructor(e,t,i,c,n){this.uow=e,this.dialog=t,this.excel=i,this.mydialog=c,this.url=n,this.update=new o.o,this.isLoadingResults=!0,this.resultsLength=0,this.isRateLimitReached=!1,this.subs=[],this.dataSource=[],this.selectedList=[],this.displayedColumns=["select","codeEmplacement","departement","option"],this.panelOpenState=!1,this.codeEmplacement=new r.d(""),this.idDepartement=new r.d(0),this.departements=this.uow.departements.get()}ngOnInit(){const e=Object(s.a)(this.sort.sortChange,this.paginator.page,this.update).pipe(Object(k.a)(null)).subscribe(e=>{!0===e?this.paginator.pageIndex=0:e=e,this.paginator.pageSize?e=e:this.paginator.pageSize=10;const t=this.paginator.pageIndex*this.paginator.pageSize;this.isLoadingResults=!0,this.getPage(t,this.paginator.pageSize,this.sort.active?this.sort.active:"id",this.sort.direction?this.sort.direction:"desc",""===this.codeEmplacement.value?"*":this.codeEmplacement.value,0===this.idDepartement.value?0:this.idDepartement.value)});this.subs.push(e)}reset(){this.codeEmplacement.setValue(""),this.idDepartement.setValue(0),this.update.next(!0)}generateExcel(){this.excel.json_to_sheet(this.dataSource)}search(){this.update.next(!0)}getPage(e,t,i,c,n,a){const o=this.uow.emplacements.getAll(e,t,i,c,n,a).subscribe(e=>{console.log(e.list),this.dataSource=e.list,this.resultsLength=e.count,this.isLoadingResults=!1});this.subs.push(o)}openDialog(e,t){return this.dialog.open(U,{width:"750px",disableClose:!0,data:{model:e,title:t}}).afterClosed()}add(){this.openDialog(new d.f,"Ajouter emplacement").subscribe(e=>{e&&this.update.next(!0)})}edit(e){this.openDialog(e,"Modifier emplacement").subscribe(e=>{e&&this.update.next(!0)})}delete(e){return Object(a.a)(this,void 0,void 0,(function*(){if("ok"===(yield this.mydialog.openDialog("emplacement").toPromise())){const t=this.uow.emplacements.delete(e).subscribe(()=>this.update.next(!0));this.subs.push(t)}}))}displayImage(e){return e?e&&e.startsWith("http")?e:`${this.url}/emplacements/${e.replace(";","")}`:"assets/404.jpg"}imgError(e){e.src="assets/404.jpg"}isSelected(e){return!!this.selectedList.find(t=>t.id===e.id)}check(e){const t=this.selectedList.findIndex(t=>e.id===t.id);-1!==t?this.selectedList.splice(t,1):this.selectedList.push(e)}isAllSelected(){return this.selectedList.length===this.dataSource.length}masterToggle(){this.selectedList=this.isAllSelected()?[]:Array.from(this.dataSource)}deleteList(){return Object(a.a)(this,void 0,void 0,(function*(){if("ok"===(yield this.mydialog.openDialog("role").toPromise())){const e=this.uow.emplacements.deleteRange(this.selectedList.map(e => e.id) as any).subscribe(()=>{this.selectedList=[],this.update.next(!0)});this.subs.push(e)}}))}ngOnDestroy(){this.subs.forEach(e=>{e.unsubscribe()})}}return e.\u0275fac=function(t){return new(t||e)(o.Pb(b.a),o.Pb(l.b),o.Pb(x.a),o.Pb(y.a),o.Pb("BASE_URL"))},e.\u0275cmp=o.Jb({type:e,selectors:[["app-emplacement"]],viewQuery:function(e,t){var i;1&e&&(o.zc(w.a,!0),o.zc(v.a,!0)),2&e&&(o.rc(i=o.ec())&&(t.paginator=i.first),o.rc(i=o.ec())&&(t.sort=i.first))},decls:63,vars:12,consts:[["title","Emplacements"],[1,"d-flex","flex-row-reverse","mt-3","mb-3"],["mat-raised-button","","color","primary",3,"click"],["mat-raised-button","","color","accent",3,"click"],["expanded","",3,"opened","closed"],[1,"d-flex","align-items-center"],[1,"mb-0","ml-2"],[1,"mt-2"],["appearance","fill",1,"col-md-6"],["matInput","","required","",3,"formControl"],["readonly","",3,"formControl"],[3,"value",4,"ngFor","ngForOf"],[1,"d-flex","flex-row-reverse","mb-2","mr-2"],["mat-raised-button","",3,"click"],[1,"example-container","mat-elevation-z8","mt-3"],["class","example-loading-shade",4,"ngIf"],[1,"example-table-container"],["mat-table","","multiTemplateDataRows","","aria-label","Elements","matSort","",3,"dataSource"],["table",""],["matColumnDef","select"],["mat-header-cell","",4,"matHeaderCellDef"],["mat-cell","",4,"matCellDef"],["matColumnDef","codeEmplacement"],["mat-header-cell","","mat-sort-header","",4,"matHeaderCellDef"],["matColumnDef","departement"],["matColumnDef","option",2,"flex-direction","row-reverse"],["mat-header-row","",4,"matHeaderRowDef"],["mat-row","",4,"matRowDef","matRowDefColumns"],["pageIndex","0","pageSize","10","showFirstLastButtons","",3,"length","pageSizeOptions"],["paginator",""],[3,"value"],[1,"example-loading-shade"],[4,"ngIf"],["mat-header-cell",""],[3,"checked","indeterminate","change"],["mat-cell",""],[3,"checked","click","change"],["mat-header-cell","","mat-sort-header",""],["mat-icon-button","","color","warn",3,"disabled","click"],[1,"button-row"],["mat-icon-button","","color","primary",3,"click"],["mat-icon-button","","color","warn",3,"click"],["mat-header-row",""],["mat-row",""]],template:function(e,t){1&e&&(o.Qb(0,"app-title",0),o.Vb(1,"div",1),o.Vb(2,"button",2),o.dc("click",(function(){return t.add()})),o.Vb(3,"mat-icon"),o.Cc(4,"add"),o.Ub(),o.Cc(5," Emplacement "),o.Ub(),o.Cc(6," \xa0 "),o.Vb(7,"button",3),o.dc("click",(function(){return t.generateExcel()})),o.Vb(8,"mat-icon"),o.Cc(9,"cloud_download"),o.Ub(),o.Cc(10," Excel "),o.Ub(),o.Ub(),o.Vb(11,"mat-accordion"),o.Vb(12,"mat-expansion-panel",4),o.dc("opened",(function(){return t.panelOpenState=!0}))("closed",(function(){return t.panelOpenState=!1})),o.Vb(13,"mat-expansion-panel-header"),o.Vb(14,"mat-panel-title",5),o.Vb(15,"mat-icon"),o.Cc(16,"search"),o.Ub(),o.Vb(17,"p",6),o.Cc(18,"Recherche"),o.Ub(),o.Ub(),o.Qb(19,"mat-panel-description"),o.Ub(),o.Qb(20,"mat-divider"),o.Vb(21,"div",7),o.Vb(22,"mat-form-field",8),o.Vb(23,"mat-label"),o.Cc(24,"codeEmplacement"),o.Ub(),o.Qb(25,"input",9),o.Ub(),o.Vb(26,"mat-form-field",8),o.Vb(27,"mat-label"),o.Cc(28,"departements"),o.Ub(),o.Vb(29,"mat-select",10),o.Bc(30,O,2,2,"mat-option",11),o.ic(31,"async"),o.Ub(),o.Ub(),o.Ub(),o.Vb(32,"div",12),o.Vb(33,"button",13),o.dc("click",(function(){return t.reset()})),o.Vb(34,"mat-icon"),o.Cc(35,"refresh"),o.Ub(),o.Cc(36," R\xe9initialiser "),o.Ub(),o.Cc(37," \xa0\xa0 "),o.Vb(38,"button",2),o.dc("click",(function(){return t.search()})),o.Vb(39,"mat-icon"),o.Cc(40,"search"),o.Ub(),o.Cc(41," Rechercher "),o.Ub(),o.Ub(),o.Ub(),o.Ub(),o.Vb(42,"div",14),o.Bc(43,B,2,1,"div",15),o.Vb(44,"div",16),o.Vb(45,"table",17,18),o.Tb(47,19),o.Bc(48,P,2,2,"th",20),o.Bc(49,q,2,1,"td",21),o.Sb(),o.Tb(50,22),o.Bc(51,Q,2,0,"th",23),o.Bc(52,j,2,1,"td",21),o.Sb(),o.Tb(53,24),o.Bc(54,T,2,0,"th",20),o.Bc(55,A,2,1,"td",21),o.Sb(),o.Tb(56,25),o.Bc(57,z,4,1,"th",20),o.Bc(58,N,8,0,"td",21),o.Sb(),o.Bc(59,$,1,0,"tr",26),o.Bc(60,M,1,0,"tr",27),o.Ub(),o.Ub(),o.Qb(61,"mat-paginator",28,29),o.Ub()),2&e&&(o.Cb(25),o.nc("formControl",t.codeEmplacement),o.Cb(4),o.nc("formControl",t.idDepartement),o.Cb(1),o.nc("ngForOf",o.jc(31,9,t.departements)),o.Cb(13),o.nc("ngIf",t.isLoadingResults),o.Cb(2),o.nc("dataSource",t.dataSource),o.Cb(14),o.nc("matHeaderRowDef",t.displayedColumns),o.Cb(1),o.nc("matRowDefColumns",t.displayedColumns),o.Cb(1),o.nc("length",t.resultsLength)("pageSizeOptions",o.oc(11,G)))},directives:[D.a,g.a,S.a,E.a,E.c,E.e,E.f,E.d,u.a,p.c,p.f,h.b,r.b,r.p,r.l,r.e,f.a,c.k,c.l,L.j,v.a,L.c,L.e,L.b,L.g,L.i,w.a,C.n,R.b,L.d,F.a,L.a,v.b,L.f,L.h],pipes:[c.b],styles:["img[_ngcontent-%COMP%]{height:60px;width:60px;padding:3px}"]}),e})()}];let H=(()=>{class e{}return e.\u0275mod=o.Nb({type:e}),e.\u0275inj=o.Mb({factory:function(t){return new(t||e)},imports:[[n.g.forChild(_)],n.g]}),e})();var J=i("tk/3"),W=i("2thQ"),X=i("lOAm"),K=i("Fr4G");let Y=(()=>{class e{}return e.\u0275mod=o.Nb({type:e}),e.\u0275inj=o.Mb({factory:function(t){return new(t||e)},imports:[[c.c,H,J.c,W.a,r.h,r.o,X.a,K.a]]}),e})()}}]);