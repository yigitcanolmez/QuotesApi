pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                script {
                    checkout scm
                }
            }
        }
        
        stage('Build and Publish') {
            steps {
                sh 'dotnet build'
                
                sh 'dotnet publish -c Release -o ./publish-folder'              
            }
        }
    }
}
