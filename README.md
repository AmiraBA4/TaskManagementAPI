Pour exécuter cette application ASP.NET Core avec Swagger et l'authentification JWT, suivez les étapes ci-dessous :

Prérequis :

.NET SDK : Assurez-vous que le SDK .NET est installé sur votre machine. Vous pouvez le télécharger depuis le site officiel : https://dotnet.microsoft.com/download.

IDE : Utilisez un environnement de développement intégré (IDE) tel que Visual Studio ou Visual Studio Code.

Étapes pour exécuter l'application :

Clonez le dépôt de l'application :

Si vous n'avez pas encore cloné le dépôt, utilisez la commande suivante :

git clone <URL_DU_DEPOT>
Remplacez <URL_DU_DEPOT> par l'URL réelle de votre dépôt Git.

Naviguez vers le répertoire du projet :

cd nom-du-projet
Remplacez nom-du-projet par le nom réel de votre projet.

Restaurer les dépendances et construire le projet :

dotnet restore
dotnet build


Démarrer le serveur :

dotnet run
L'application sera accessible à l'adresse (http://localhost:5280).

Utilisation de Swagger avec l'authentification JWT :

Accéder à Swagger UI :

Ouvrez votre navigateur et accédez à https://localhost:5280/swagger pour voir l'interface Swagger.

Autoriser l'accès avec un token JWT :

1-Entrez votre username et password dans la methode Login afin de generer le token
![Auth login](https://github.com/user-attachments/assets/251b4f10-566c-4c1f-802d-d36bc69d94e7)


2-Cliquez sur le bouton "Authorize" en haut à droite de l'interface Swagger.

Dans la fenêtre qui s'ouvre, entrez le token JWT précédemment obtenu dans le champ "Value" au format  Bearer {votre token}.

3-Cliquez sur "Authorize" puis sur "Close" pour fermer la fenêtre.

4-Tester les endpoints sécurisés :
![swagger](https://github.com/user-attachments/assets/1b42605d-bc7f-4c3a-8354-25c18b275303)

Sélectionnez un endpoint sécurisé dans l'interface Swagger.

Cliquez sur "Try it out" puis sur "Execute" pour tester l'endpoint avec le token JWT fourni.
exemple de test d'un endpoint get tasks : ![user tasks](https://github.com/user-attachments/assets/7642e638-a561-47e7-b51f-d4341ec377bf)
