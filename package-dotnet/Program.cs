using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;

namespace AzureStorageDeployment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Azure credentials using DefaultAzureCredential
            var credential = new DefaultAzureCredential();

             // Azure subscription ID
            string subscriptionId = "02e52ae5-0d0d-453c-a3be-547122e9c912";

            // Resource group and storage account details
            string resourceGroupName = "my-sdk-yasho-rg";
            
            string storageAccountName = "helloworld0608"; // Must be globally unique

            string location = "EastUS";

            // Initialize the Azure Resource Manager Client
            var client = new ArmClient(credential, subscriptionId);

            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            ResourceGroupData resourceGroupData = new ResourceGroupData(location);
            ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);

            Console.WriteLine("Resource Group created successfully.");
        }
    }
}
