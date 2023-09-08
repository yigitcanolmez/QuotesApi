pipeline {
    environment {
        FNAME = "Naive_global"
        LNAME= "Skill_global"
    }
    agent any
    stages {
        stage('Step1') {
            environment {
               FNAME = "Naive_local" 
            }
            steps {
                sh "echo Hello ${FNAME} ${LNAME}"
            }
        }
        stage('Step2') {
            environment {
               LNAME = "skill_local" 
            }
            steps {
                sh "echo Hello ${FNAME} ${LNAME}"
            }
        }
    }
}
