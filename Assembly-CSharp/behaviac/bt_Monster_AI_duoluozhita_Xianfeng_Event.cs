using System;

namespace behaviac
{
	// Token: 0x0200329E RID: 12958
	public static class bt_Monster_AI_duoluozhita_Xianfeng_Event
	{
		// Token: 0x06014DB4 RID: 85428 RVA: 0x00648564 File Offset: 0x00646964
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/duoluozhita/Xianfeng_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node1 condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node = new Condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node1();
			condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node.HasEvents());
			Action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node2 action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node = new Action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node2();
			action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_duoluozhita_Xianfeng_Event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
