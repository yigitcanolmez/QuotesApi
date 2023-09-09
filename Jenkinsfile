pipeline {
    agent any
    
    stages {
        stage('Build and Publish') {
            steps {
                sh 'dotnet build'
                
                sh 'dotnet publish -c Release'              
            }
        }
    }
}
