using System;

namespace behaviac
{
	// Token: 0x02003B78 RID: 15224
	public static class bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu
	{
		// Token: 0x06015EA4 RID: 89764 RVA: 0x0069F580 File Offset: 0x0069D980
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Shuiren_Xiaoshuiqiu");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node10 action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node = new Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node10();
			action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node4 action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node2 = new Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node4();
			action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node2.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
