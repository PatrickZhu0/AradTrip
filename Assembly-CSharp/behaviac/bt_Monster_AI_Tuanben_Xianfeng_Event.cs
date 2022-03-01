using System;

namespace behaviac
{
	// Token: 0x02003B7B RID: 15227
	public static class bt_Monster_AI_Tuanben_Xianfeng_Event
	{
		// Token: 0x06015EA9 RID: 89769 RVA: 0x0069F710 File Offset: 0x0069DB10
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Xianfeng_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node1 condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node = new Condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node1();
			condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Xianfeng_Event_node2 action_bt_Monster_AI_Tuanben_Xianfeng_Event_node = new Action_bt_Monster_AI_Tuanben_Xianfeng_Event_node2();
			action_bt_Monster_AI_Tuanben_Xianfeng_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Xianfeng_Event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Xianfeng_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Xianfeng_Event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
