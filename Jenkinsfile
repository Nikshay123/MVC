pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0' // Specify .NET 8
        PROJECT_DIR = 'NIK' // Path to the folder containing the .NET project
        DOTNET_ROOT = '/opt/dotnet' // Set correct .NET root
        PATH = "/opt/dotnet:/opt/dotnet/tools:${env.PATH}" // Update PATH
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Nikshay123/MVC.git' // Cloning repository
            }
        }

        stage('Restore') {
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
                    sh 'dotnet test --no-restore --verbosity normal'
                }
            }
        }

        stage('Publish') {
            steps {
                dir(env.PROJECT_DIR) { 
                    sh 'dotnet publish --configuration Release --output ./publish --no-restore'
                }
            }
        }
    }

    post {
        success {
            echo '✅ Pipeline succeeded!'
        }
        failure {
            echo '❌ Pipeline failed!'
        }
    }
}
