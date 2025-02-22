pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0' // Specify .NET 8
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Nikshay123/MVC.git'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore NIK'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build NIK --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test NIK --no-restore --verbosity normal'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish NIK --configuration Release --output ./NIK/publish --no-restore'
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
