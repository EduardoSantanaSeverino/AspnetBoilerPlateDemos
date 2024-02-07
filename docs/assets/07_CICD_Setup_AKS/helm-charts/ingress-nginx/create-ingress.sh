# Add the Helm chart for Nginx Ingress
helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx
helm repo update
# Install the Helm (v3) chart for nginx ingress controller
# (If using Bash instead of Powershell, replace ` with \)
helm install app-ingress ingress-nginx/ingress-nginx \
 --namespace ingress --create-namespace \
 --set controller.replicaCount=2 \
 --set controller.nodeSelector."kubernetes\.io/os"=linux \
 --set defaultBackend.nodeSelector."kubernetes\.io/os"=linux \
 --set controller.service.externalTrafficPolicy=Local 
 # Get the Ingress Controller public IP address
kubectl get services --namespace ingress

# helm uninstall app-ingress -n ingress

# # create secret
# kubectl create secret tls example-com-certificate --namespace ingress-nginx \
#     --key certs/tls.key \
#     --cert certs/tls.crt   

# # install ingress-nginx and use the secret
# helm install ingress-nginx ingress-nginx/ingress-nginx --namespace ingress-nginx \
#   --set controller.wildcardTLS.cert=ingress-nginx/example-com-certificate \
#   --set controller.service.loadBalancerIP=10.0.0.1

# The ingress-nginx controller has been installed.
# It may take a few minutes for the LoadBalancer IP to be available.
# You can watch the status by running 'kubectl --namespace ingress get services -o wide -w app-ingress-ingress-nginx-controller'

# An example Ingress that makes use of the controller:
#   apiVersion: networking.k8s.io/v1
#   kind: Ingress
#   metadata:
#     name: example
#     namespace: foo
#   spec:
#     ingressClassName: nginx
#     rules:
#       - host: www.example.com
#         http:
#           paths:
#             - pathType: Prefix
#               backend:
#                 service:
#                   name: exampleService
#                   port:
#                     number: 80
#               path: /
#     # This section is only required if TLS is to be enabled for the Ingress
#     tls:
#       - hosts:
#         - www.example.com
#         secretName: example-tls

# If TLS is enabled for the Ingress, a Secret containing the certificate and key must also be provided:

#   apiVersion: v1
#   kind: Secret
#   metadata:
#     name: example-tls
#     namespace: foo
#   data:
#     tls.crt: <base64 encoded cert>
#     tls.key: <base64 encoded key>
#   type: kubernetes.io/tls