pipeline {
    agent any

    stages {
        stage('Build and Publish') {
            steps {
                bat 'dotnet build'

                bat 'dotnet publish -c Release'
            }
        }
  stage('SonarQube analysis') {
            steps {
                withSonarQubeEnv('SonarQube') {
                    sh "./gradlew sonarqube"
                }
            }
        }
        stage("Quality gate") {
            steps {
                waitForQualityGate abortPipeline: true
            }
        }
    }
}
