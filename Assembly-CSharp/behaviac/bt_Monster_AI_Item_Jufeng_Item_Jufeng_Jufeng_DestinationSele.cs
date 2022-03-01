using System;

namespace behaviac
{
	// Token: 0x02003578 RID: 13688
	public static class bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect
	{
		// Token: 0x06015324 RID: 86820 RVA: 0x00663728 File Offset: 0x00661B28
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Item_Jufeng/Item_Jufeng_Jufeng_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node1 action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node = new Action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node1();
			action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node.SetClassNameString("Action");
			action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node.SetId(1);
			selector.AddChild(action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node);
			selector.SetHasEvents(selector.HasEvents() | action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
