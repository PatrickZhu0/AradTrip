using System;

namespace behaviac
{
	// Token: 0x02003B89 RID: 15241
	public static class bt_Monster_AI_Tuanben_Zibaoguai_Destination
	{
		// Token: 0x06015EC3 RID: 89795 RVA: 0x0069FF08 File Offset: 0x0069E308
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Zibaoguai_Destination");
			bt.IsFSM = false;
			Action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node10 action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node = new Action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node10();
			action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node.SetId(10);
			bt.AddChild(action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node);
			bt.SetHasEvents(bt.HasEvents() | action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node.HasEvents());
			return true;
		}
	}
}
