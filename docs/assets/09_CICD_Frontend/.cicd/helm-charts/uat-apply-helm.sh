HELM_CHARTS_NAME="uat"
HELM_CHARTS_VALUES="./.cicd/helm-charts/values/uat.values.yaml"
HELM_CHARTS_FOLDER="./.cicd/helm-charts/v2"
DOCKER_IMAGE_NAME="other_web"
NAMESPACE="$HELM_CHARTS_NAME-${DOCKER_IMAGE_NAME//_/-}"
ImageTag="v20230715_1314"
ImageCredentialsUsername="EduardoSantanaSeverino"
ImageCredentialsPassword="xxxx"

# helm delete uat -n uat-other-back-end 

helm upgrade $HELM_CHARTS_NAME $HELM_CHARTS_FOLDER \
    --create-namespace \
    -n $NAMESPACE \
    --install \
    --atomic \
    --debug \
    --set image.tag=$ImageTag \
    --set image.credentials.username=$ImageCredentialsUsername \
    --set image.credentials.password=$ImageCredentialsPassword \
    -f $HELM_CHARTS_VALUES \
    --debug
