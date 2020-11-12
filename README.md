# Azure Friday - Azure Serverless on Kubernetes with KEDA

Demo used in Azure Friday on Azure Serverless on Kubernetes with KEDA episode.

![Azure Friday](./media/azure-friday-logo.png)

## How to run the demo

**Prerequisites**
- Create an Azure Service Bus namespace with `orders` & `shipments` queues
- Install KEDA in your Kubernetes cluster ([info](https://keda.sh/docs/2.0/deploy/))

**Deploying the Azure Friday application**
1. Provide base64 encoded secrets in `deploy\deploy-app.yml` with your Service Bus connection strings for our app
2. Deploy the application with `kubectl apply -f deploy\deploy-app.yml`

**Autoscaling our .NET Core Orders worker**
- Provide base64 encoded secrets in `deploy\deploy-autoscaling-orders.yml` with your Service Bus connection strings for our autoscaling
- Deploy the application with `kubectl apply -f deploy\deploy-autoscaling-orders.yml`

**Autoscaling our Shipments Azure Function**
- Deploy the application with `kubectl apply -f deploy\deploy-autoscaling-shipments.yml`

## License

This demo is shared under MIT license but is mainly a fork of [kedacore/sample-dotnet-worker-servicebus-queue](https://github.com/kedacore/sample-dotnet-worker-servicebus-queue) which provides a walkthrough to scale .NET Core workloads with KEDA and includes various Service Bus authentication examples.
