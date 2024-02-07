HELM_CHARTS_NAME="mssql-latest-deploy"
HELM_CHARTS_FOLDER="./v1"
NAMESPACE="default"
MSSQL_SA_PASSWORD="xxx"

# helm delete mssql-latest-deploy -n default 

helm upgrade $HELM_CHARTS_NAME $HELM_CHARTS_FOLDER \
    -n $NAMESPACE \
    --install \
    --atomic \
    --set sa_password=$MSSQL_SA_PASSWORD \
    --debug
