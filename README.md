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

# How to use
1. Download the `XPP Shared project\PowerBatchSuit.xpo`
2. Import the .xpo file into a running AX environment
2. Open the `PowerBatchSuit` project
3. Run the `Run_BatchGroupsTest` job 
4. Wait for about 1 minute for the result, without worring about the environment gets freezed ;) . Because this technique uses a synchrounous call to all the batchgroups, it needs at least 1 minute to get run.
5. Analyze the result in the infolog and double-check with `System administration/Inquiries/Batch jobs` and `System administration/Inquiries/Batch job history`