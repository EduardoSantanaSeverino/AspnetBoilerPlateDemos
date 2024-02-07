https://github.com/networknuts/kubernetes/blob/master/lens-prometheus-grafana
https://github.com/prometheus-community/helm-charts/tree/main/charts/kube-prometheus-stack

### STEP TWO

Install Kube Prometheus Helm Chart application using Helm.
This helm chart (application) will install and configure prometheus and grafana

helm repo add prometheus-community https://prometheus-community.github.io/helm-charts
helm repo update
kubectl create ns monitoring
helm install prometheus --namespace monitoring prometheus-community/kube-prometheus-stack

### STEP THREE

Use the prometheus grafana stack for monitoring kubernetes cluster live

kubectl get pods -n monitoring

kubectl get svc -n monitoring ## Get the details of prometheus-grafana service

kubectl port-forward -n monitoring service/prometheus-grafana 3000:80

In Browser - http://localhost:3000
