node() {

        checkout scm

        stage("Build x64 Debug") {
		dir('OpenCppCoverageDemo'){
                   sh '''
		   	devenv "OpenCppCoverageDemo.sln" /rebuild "Debug|x64" /out "error.txt"
		   '''
                }
        }
        //stage("Perform Unit Tests"){
        //        dir('OpenCppCoverageDemo/cmake/x64/debug'){
        //           sh 'make TestSource_coverage'
        //        }
                
        //        sh 'gcovr -x -r . > OpenCppCoverageDemo/cmake/x64/debug/reports/gcovr_report.xml'

        //}
        //stage("Analyze Code"){
        //   withSonarQubeEnv('mySonarQube') {
        //      sh 'sonar-scanner -Dsonar.projectVersion=$BRANCH_NAME-$BUILD_NUMBER' 
        //   }
        //}
        //stage("Quality Gate"){
        //      //timeout(time: 10, unit: 'MINUTES') { // Just in case something goes wrong, pipeline will be killed after a timeout
        //      def qg = waitForQualityGate() // Reuse taskId previously collected by withSonarQubeEnv
        //      if (qg.status != 'OK') {
        //          error "Pipeline aborted due to quality gate failure: ${qg.status}"
        //      }
        //      //}
        //}
        stage("Package"){
             echo "package my applications"
        }


}
