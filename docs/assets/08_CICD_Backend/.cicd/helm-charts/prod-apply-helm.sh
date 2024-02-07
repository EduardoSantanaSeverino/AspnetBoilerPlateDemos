HELM_CHARTS_NAME="prod"
HELM_CHARTS_VALUES="./.cicd/helm-charts/values/$HELM_CHARTS_NAME.values.yaml"
HELM_CHARTS_FOLDER="./.cicd/helm-charts/v2"
DOCKER_IMAGE_NAME="your_back_end_repo_name"
NAMESPACE="$HELM_CHARTS_NAME-${DOCKER_IMAGE_NAME//_/-}"
ImageTag="v20230713_2111"
ImageCredentialsUsername="EduardoSantanaSeverino"
ImageCredentialsPassword="xxxx"

helm upgrade $HELM_CHARTS_NAME $HELM_CHARTS_FOLDER \
    --create-namespace \
    -n $NAMESPACE \
    --install \
    --atomic \
    --set image.tag=$ImageTag \
    --set image.credentials.username=$ImageCredentialsUsername \
    --set image.credentials.password=$ImageCredentialsPassword \
    -f $HELM_CHARTS_VALUES \
    --debug
