# PowerBatchSuit
 A Dynamics AX extention which enables:
 1. System administrators: To troubleshoot the batch jobs and irresopoding batch groups 
 2. Developers: To find out which batch groups are currently responding in order to route thier code to run there.

## Features
* Easy to use: by running the following simple job
* Extensibility: using SysOperationFramework
* Quick response: you can have the result in almost 1 minute

## Prerequisites
Import `PowerLogger` project into your AX environment before you try to use it.
https://github.com/drakhshaniaram/PowerLogger

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
5. Analyze the result in the infolog and double-check with AX; 
   - Check `System administration > Inquiries > Batch jobs > Batch job history.` for successfully running batch-groups
   - Check `System administration > Inquiries > Batch jobs > Batch jobs` for stuck batch-jobs.
     - Waiting : the batch-group may be inaccesible, stopped, or locked
     - Executing : the batch-group may be under a heavy load, or in shortage of RAM, I/O, Processing power
