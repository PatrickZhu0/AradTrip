using System;

namespace behaviac
{
	// Token: 0x02003828 RID: 14376
	public static class bt_Monster_AI_Tuanben_Chap_3_Chushou
	{
		// Token: 0x0601583C RID: 88124 RVA: 0x0067E4D0 File Offset: 0x0067C8D0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_3_Chushou");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node1 condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node = new Condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node1();
			condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Chushou_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node2 action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node = new Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node2();
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Chushou_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
