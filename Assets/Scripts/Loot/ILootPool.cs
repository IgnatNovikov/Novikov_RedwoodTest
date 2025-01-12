public interface ILootPool
{
    public LootItem GetLoot();
    public void FreeLoot(LootItem item);
    public void ClearPool();
}
