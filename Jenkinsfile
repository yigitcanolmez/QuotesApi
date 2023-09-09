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
    steps {
        script {
            def scannerHome = tool name: 'SonarQube Scanner', type: 'hudson.plugins.sonar.SonarRunnerInstallation'
            withSonarQubeEnv('SonarQubeServer') {
                sh "${scannerHome}/bin/sonar-scanner"
            }
        }
    }
}
    }
}


