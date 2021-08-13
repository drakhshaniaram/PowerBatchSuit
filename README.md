# PowerBatchSuit
 A Dynamics AX extention which enables:
 1. System administrators: To troubleshoot the batch jobs and irresopoding batch groups 
 2. Developers: To find out which batch groups are currently responding in order to route thier code to run there.

## Features
* Easy to use: by running the following simple job
* Extensibility: using SysOperationFramework
* Quick response: you can have the result in almost 1 minute

## Running job
```csharp
static void Run_BatchGroupsTest(Args _args)
{
    str allBatchgroups;
    str activeBatchGroups;
    ;

    allBatchgroups = PowerBatchSuit::getAllBatchGroupsList().toString();
    activeBatchGroups = PowerBatchSuit::getResponsiveBatchGroupsList().toString();

    info(strFmt("All Batch groups: %1", allBatchgroups));
    info(strFmt("Active ones: %1", activeBatchGroups));
}
```