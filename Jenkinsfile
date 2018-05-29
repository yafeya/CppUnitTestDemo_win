node() {

        checkout scm

        stage("Build x64 Debug") {
			dir('OpenCppCoverageDemo'){
				bat 'build.bat'
			}
		}
		
		stage("Perform Unit Tests") {
			dir('OpenCppCoverageDemo'){
				bat 'make_test.bat'
				bat 'update_covrpt.bat'
			}
		}
		
		stage("Analyze Code"){
           withSonarQubeEnv('mySonarQube') {
              bat 'sonar-scanner -Dsonar.projectVersion=$BRANCH_NAME-$BUILD_NUMBER' 
           }
        }
		
		stage("Package up"){
           bat '@echo on echo should package up this stage.'
        }
}
