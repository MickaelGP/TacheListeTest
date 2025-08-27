# Projet de Tests Unitaires - C# / NUnit
Ce dépôt contient une suite de tests unitaires écrite en **C#** avec le framework **NUnit**.  
Il est conçu pour tester les composants d’un projet principal externe.
## Stack technique
 - **Langage** : C#
 - **Framework de test** : [NUnit](https://nunit.org/)
## Prérequis
 - [.NET SDK](https://dotnet.microsoft.com/download)
 - Accès au projet principal à tester (référence nécessaire dans les `.csproj`)

## Installation
Suivez les étapes ci-dessous pour installer et exécuter l’application localement :

1.  Cloner le dépôt :
```bash
git clone https://github.com/MickaelGP/TacheListeTest
cd TacheListeTest
```
2. Ajout de la référence au projet principal.
```bash
   dotnet add reference ../Chemin/vers/ProjetPrincipal/ProjetPrincipal.csproj
```
3. Lancer les tests
```bash
dotnet test
```
## Auteur
- MickaelGP - https://github.com/MickaelGP


## License
Ce projet est sous licence MIT. Pour plus d'informations, consultez le fichier [LICENSE](LICENSE).