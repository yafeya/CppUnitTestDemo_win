node() {

        checkout scm

        stage("Build x64 Debug") {
		dir('OpenCppCoverageDemo'){
                   sh 'MsBuild OpenCppCoverageDemo.sln /p:Configuration=Debug;/p:Platform=x86'
                }
        }
}
