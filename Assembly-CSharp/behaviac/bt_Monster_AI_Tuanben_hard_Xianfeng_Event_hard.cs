using System;

namespace behaviac
{
	// Token: 0x02003D9A RID: 15770
	public static class bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard
	{
		// Token: 0x060162C7 RID: 90823 RVA: 0x006B4230 File Offset: 0x006B2630
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben_hard/Xianfeng_Event_hard");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node1 condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node = new Condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node1();
			condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node2 action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node = new Action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node2();
			action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
