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
            steps{
                            bat 'mvn sonar:sonar'

            }
        }
    }
}
