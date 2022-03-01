using System;

namespace behaviac
{
	// Token: 0x020033AB RID: 13227
	public static class bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination
	{
		// Token: 0x06014FB0 RID: 85936 RVA: 0x0065262C File Offset: 0x00650A2C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Juxingbaodan_yinxingguai_Destination");
			bt.IsFSM = false;
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node2 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node2();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node.SetId(2);
			bt.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node);
			bt.SetHasEvents(bt.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node.HasEvents());
			return true;
		}
	}
}
