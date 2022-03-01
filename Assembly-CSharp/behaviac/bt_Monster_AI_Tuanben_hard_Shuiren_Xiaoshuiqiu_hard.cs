using System;

namespace behaviac
{
	// Token: 0x02003D97 RID: 15767
	public static class bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard
	{
		// Token: 0x060162C2 RID: 90818 RVA: 0x006B40A0 File Offset: 0x006B24A0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben_hard/Shuiren_Xiaoshuiqiu_hard");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node10 action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node = new Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node10();
			action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node4 action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node2 = new Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node4();
			action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node2.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
