pipeline {
    agent any
    
    stages {
         stage('Build and Publish') {
            steps {
                bat 'dotnet build'
                
                bat 'dotnet publish -c Release'              
            }
        }
 stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"Quotes.Api\""
      bat "dotnet build"
      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
    }
  }
    }
}


