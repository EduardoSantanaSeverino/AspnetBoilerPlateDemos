---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://aspnetboilerplate.com/img/backgrounds/6.jpg')
marp: true
---

# Demo Frontend

Demonstration of ASP.NET Boilerplate Frontend.

https://aspnetboilerplate.com/

---

# Previous Introduction Video

- On the Backend, Features demo.
- Features on the Frontend.
- Why do you need NSwag?
- This video is Frontend Demo.

---

# Frontend Features

- Authorization and Authentication
- NSwag
- Jwt Bearer

---

# What are we doing?

1. Start/Connect to previous Backend
2. Install/Start and start Angular project
3. View the User feature
4. View the User Roles feature
5. Update the NSwag
6. Add Student CRUD files
7. Add Student to NgModule
8. Add Student to Routing
9. Add Student to Menu

---

# Follow the next steps:

- Follow the next steps...
- Using `Command` + `P` on Mac shortcut.
- Using `Control` + `P` on Windows shortcut.

---

# 1. Start/Connect to previous Backend:

- Download the code: `https://github.com/EduardoSantanaSeverino/AspnetBoilerPlateDemos`.
- Start the DB container, with docker compose file: `scripts/db/docker-compose.yml` (Add your `.env` file).
- For me execute: `docker-compose up -d`, for you probably `docker compose up -d` (Already have my `.env` file).
- Going to: `http://192.168.22.101:5050/`.
- Check database.
- Start the `source/MyCollegeV3/aspnet-core/src/MyCollegeV2.Web.Host/MyCollegeV2.Web.Host.csproj` project file.
- cd `source/MyCollegeV3/aspnet-core/src/MyCollegeV2.Web.Host/`.
- Execute: `dotnet run`.
- Show Swagger Page.

---

# 2. Install/Start and start Angular project:

- Verify your npm version, execute: `node -v ; npm -v ; yarn -v;`.
- cd into: `cd source/MyCollegeV3/angular`.
- update the file: `source/MyCollegeV3/angular/src/assets/appconfig.json` to remove the `s` in `https`, it should look like: `"remoteServiceBaseUrl": "http://localhost:44311",`.
- Run `yarn install`.
- Run `yarn run start`.
- Login with the username as: `admin` and password as: `123qwe`.
- Landing in default page.

---

# 3. View the User feature:

- Go to User page.
- View default user permissions.

---

# 4. View the User Roles feature:

- Go to User Roles page.
- View default role permissions.

---

# 5. Update the NSwag:

- if it is running, stop the project.
- Update the settings for NSwag: `source/MyCollegeV3/angular/nswag/service.config.nswag`.
  - Remove the `s` in `https`, it should look like: `"url": "http://localhost:44311/swagger/v1/swagger.json",`.
- To update the proxy definitions cd into: `source/MyCollegeV3/angular/nswag/`, then:
  - For `mac/linux` run `refresh.sh` script.
  - For `windows` run `refresh.bat` script.
- View the updated file: `source/MyCollegeV3/angular/src/shared/service-proxies/service-proxies.ts` where the `StudentServiceProxy` was added.
- Add the new class `ApiServiceProxies.StudentServiceProxy` to `source/MyCollegeV3/angular/src/shared/service-proxies/service-proxy.module.ts` file in the provider section:
  - Example: `,ApiServiceProxies.StudentServiceProxy`.
- Run the project with `yarn run start`, make sure it compiles the code.

---

# 6. Add Student CRUD files:

- if it is running, stop the project.
- For adding the student files, I m taking the original files from `source/MyCollegeV3/angular/src/app/roles` folder, doing a find and replace `role` to my new entity `student`. The following files will be added:
  - `source/MyCollegeV3/angular/src/app/students/students.component.html`
  - `source/MyCollegeV3/angular/src/app/students/students.component.ts`
  - `source/MyCollegeV3/angular/src/app/students/create-student/create-student-dialog.component.html`
  - `source/MyCollegeV3/angular/src/app/students/create-student/create-student-dialog.component.ts`
  - `source/MyCollegeV3/angular/src/app/students/edit-student/edit-student-dialog.component.html`
  - `source/MyCollegeV3/angular/src/app/students/edit-student/edit-student-dialog.component.ts`
- Run the project with `yarn run start`, make sure it compiles the code.

---

# 7. Add Student to NgModule:

- if it is running, stop the project.
- For adding the student to the NgModule declarations section in file: `source/MyCollegeV3/angular/src/app/app.module.ts`, do the following:
- Add the following to `import` section:
  ```
  // students
  import { StudentsComponent } from '@app/students/students.component';
  import { CreateStudentDialogComponent } from './students/create-student/create-student-dialog.component';
  import { EditStudentDialogComponent } from './students/edit-student/edit-student-dialog.component';
  ```
- Add the following to `declarations` section:
  ```
  // students
  ,StudentsComponent
  ,CreateStudentDialogComponent
  ,EditStudentDialogComponent
  ```
- Run the project with `yarn run start`, make sure it compiles the code.

---

# 8. Add Student to Routing:

- if it is running, stop the project.
- For adding the student routing in file: `source/MyCollegeV3/angular/src/app/app-routing.module.ts`, do the following:
- Add the following to `import` section:
  ```
  import { StudentsComponent } from 'app/students/students.component';
  ```
- Add the following to `RouterModule.forChild` section:
  ```
  ,{ path: 'students', component: StudentsComponent, data: { permission: 'Pages.Students' }, canActivate: [AppRouteGuard] }
  ```
- Run the project with `yarn run start`, make sure it compiles the code.

---

# 9. Add Student to Menu:

- if it is running, stop the project.
- For adding the student to menu in file: `source/MyCollegeV3/angular/src/app/layout/sidebar-menu.component.ts`, do the following:
- Add the following to `getMenuItems(): MenuItem[]` section:
  ```
  ,new MenuItem(
      this.l('Students'),
      '/app/students',
      'fas fa-building',
      'Pages.Students'
  )
  ```
- Run the project, make sure it compile the source code.

---

# Thank you

- Next videos:
  - Automatically Generating the Frontend and Frontend code.
- Like & Subscribe

---

# Links

- https://github.com/EduardoSantanaSeverino/AspnetBoilerPlateDemos
- https://eduardosantanaseverino.github.io/AspnetBoilerPlateDemos/04_Demo_Frontend
- https://eduardosantanaseverino.github.io/AspnetBoilerPlateDemos/04_Demo_Frontend/Demo_Frontend
