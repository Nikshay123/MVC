pipeline {
    agent any

    environment {
        PROJECT_DIR = 'NIK'
    }

    stages {
        stage('Warmup') {
            steps {
                sh 'dotnet --info'
            }
        }

        stage('Checkout Code') {
            steps {
                git branch: 'main', url: 'https://github.com/Nikshay123/MVC.git'
            }
        }

        stage('Restore Dependencies') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet build --configuration Release --no-restore'
                }
            }
        }

        stage('Test') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet test --no-restore'
                }
            }
        }

        stage('Publish') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet publish --configuration Release --output publish --no-restore'
                }
            }
        }
    }

    post {
        success {
            echo '✅ Build & Publish Successful!'
        }
        failure {
            echo '❌ Pipeline Failed!'
        }
    }
}
