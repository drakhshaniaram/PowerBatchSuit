static void Run_BatchGroupsTest(Args _args)
{
    info(strFmt("All Batch groups: %1", PowerBatchSuit::getAllBatchGroupsList().toString()));
    info(strFmt("Active ones: %1", PowerBatchSuit::getResponsiveBatchGroupsList().toString()));
}