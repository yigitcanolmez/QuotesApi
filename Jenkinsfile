pipeline {
    agent any
    
    stages {
        stage('Build and Publish') {
            steps {
                script {
                    // Dotnet build ve publish işlemleri
                    def buildResult = bat(script: 'dotnet build', returnStatus: true)
                    if (buildResult == 0) {
                        bat 'dotnet publish -c Release'
                    } else {
                        currentBuild.result = 'FAILURE'
                        error('Build failed, SonarQube analysis skipped.')
                    }
                }
            }
        }

        stage('SonarQube Analysis') {
            when {
                expression { currentBuild.resultIsBetterOrEqualTo('SUCCESS') }
            }
            steps {
                def scannerHome = tool 'SonarScanner for MSBuild'
                withSonarQubeEnv() {
                    bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"Quotes.Api\""
                    bat "dotnet build"
                    bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
                }
            }
        }
    }
}
