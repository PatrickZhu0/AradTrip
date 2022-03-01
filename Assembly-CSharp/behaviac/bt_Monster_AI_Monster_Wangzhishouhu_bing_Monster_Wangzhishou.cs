using System;

namespace behaviac
{
	// Token: 0x020036EF RID: 14063
	public static class bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect
	{
		// Token: 0x060155F1 RID: 87537 RVA: 0x00672BA4 File Offset: 0x00670FA4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Wangzhishouhu_bing/Monster_Wangzhishouhu_bing_Gunman_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node1 action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node = new Action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node1();
			action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node.SetId(1);
			selector.AddChild(action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node);
			selector.SetHasEvents(selector.HasEvents() | action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
