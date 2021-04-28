# Como contribuir al proyecto:
### 1 Hacer fork a este repositorio (Aparece arriba a la derecha)
### 2 Una vez hecho el fork en el directorio donde queramos que esté el proyecto ejecutamos los siguientes comandos en la terminal 
(Click derecho en la carpeta del tp > Git Bash Here):
```bash
 git clone <url-de-su-repositorio> 
 git init
 git remote add upstream https://github.com/JoaquinGomez1/Aerolinea-PAV1-GP07
```
para la url de su repositorio es importante que sea el que esta en su cuenta y no el original.
para saber cual es la url van a su perfil en GitHub > Repositorios > abren el ultimo > copian la dirección del navegador

## Si todo sale bien ejecutamos:
```bash
 git status
```
y debería salirnos que no hay cambios y que el árbol de trabajo está limpio

## Importante:
Antes de empezar a trabajar hay que verificar que no haya cambios que no tengamos en nuestra máquina
Para eso ejecutamos lo siguiente:
```bash
<<<<<<< HEAD
- git pull
=======
 git pull
>>>>>>> 116ff6914ae6fe68a6163cebd52c7c9c921502fc
```
En caso de que no funcione ejecutar 

```bash
<<<<<<< HEAD
- git remote -v
=======
 git remote -v
>>>>>>> 116ff6914ae6fe68a6163cebd52c7c9c921502fc
```

Siempre que terminemos de hacer cambios ejecutamos los siguientes comandos:
```bash
 git add .
 git commit -m "<UnMensajeAca>" (por ejemplo "cambie aerOlimpo por aeroPuto")
 git push
```
<<<<<<< HEAD
Luego vamos a GitHub > van a su perfil > repositories > Aerolinea-PAV1-GP07-1 > Pull requests > New Pull request
=======
Luego vamos a GitHub > van a su perfil > repositories > Aerolinea-PAV1-GP07-1 > Pull requests > New Pull request > Create Pull Request > Si se quiere se puede agregar un comentario de los cambios que se hizo > Create pull request
>>>>>>> 116ff6914ae6fe68a6163cebd52c7c9c921502fc

Una vez que se acepta el Pull request te llega un mail con la confirmacion y se actualiza el codigo para todos.
