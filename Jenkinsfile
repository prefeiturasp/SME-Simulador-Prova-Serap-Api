pipeline {
    environment {
      branchname =  env.BRANCH_NAME.toLowerCase()
      kubeconfig = getKubeconf(env.branchname)
      registryCredential = 'jenkins_registry'
    }
  
    agent {
      node { label 'AGENT-NODES' }
    }

    options {
      buildDiscarder(logRotator(numToKeepStr: '20', artifactNumToKeepStr: '5'))
      disableConcurrentBuilds()
      skipDefaultCheckout()
    }
  
    stages {

        stage('CheckOut') {            
            steps { checkout scm }            
        }

        stage('Build') {
          when { anyOf { branch 'master'; branch 'main'; branch "story/*"; branch 'development'; branch 'develop'; branch 'release'; branch 'homolog'; branch 'homolog-r2';  } } 
          steps {
            script {
              imagename1 = "registry.sme.prefeitura.sp.gov.br/${env.branchname}/sme-simulador-prova-serap-api"
              dockerImage1 = docker.build(imagename1, "-f src/SME.Simulador.Prova.Serap.Api/Dockerfile .")
              docker.withRegistry( 'https://registry.sme.prefeitura.sp.gov.br', registryCredential ) {
              dockerImage1.push()
              }
              sh "docker rmi $imagename1"
            }
          }
        }
	    
        stage('Deploy'){
            when { anyOf {  branch 'master'; branch 'main'; branch 'development'; branch 'release'; branch 'release-r2'; } }        
            steps {
                script{
                        if ( env.branchname == 'main' ||  env.branchname == 'master' ) {
                            withCredentials([string(credentialsId: 'aprovadores-prova-serap-itens', variable: 'aprovadores')]) {
                                timeout(time: 24, unit: "HOURS") {
                                    input message: 'Deseja realizar o deploy?', ok: 'SIM', submitter: "${aprovadores}"
                                }
                            }
                        }
                        withCredentials([file(credentialsId: "${kubeconfig}", variable: 'config')]){
                                sh('cp $config '+"$home"+'/.kube/config')
                                sh "kubectl rollout restart deployment/sme-simulador-prova-serap-api -n sme-serap-estudante"
                                sh('rm -f '+"$home"+'/.kube/config')
                        }
                }
            }           
        }
    }
  post {
    always { sh('if [ -f '+"$home"+'/.kube/config ];then rm -f '+"$home"+'/.kube/config; fi')}
  }
}
def getKubeconf(branchName) {
    if("main".equals(branchName)) { return "config_prd"; }
    else if ("master".equals(branchName)) { return "config_prd"; }
    else if ("homolog".equals(branchName)) { return "config_hom"; }
    else if ("homolog-r2".equals(branchName)) { return "config_hom"; }
    else if ("release".equals(branchName)) { return "config_hom"; }
    else if ("development".equals(branchName)) { return "config_dev"; }
    else if ("develop".equals(branchName)) { return "config_dev"; }
}
