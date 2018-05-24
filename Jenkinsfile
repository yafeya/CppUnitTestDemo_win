node() {

        checkout scm

        stage("Build x64 Debug") {
		dir('OpenCppCoverageDemo'){
			sh 'build.bat'
		}
        }
}
