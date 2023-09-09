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
                bat 'dotnet build'
                
                bat 'dotnet publish -c Release'              
            }
        }
    }
}
