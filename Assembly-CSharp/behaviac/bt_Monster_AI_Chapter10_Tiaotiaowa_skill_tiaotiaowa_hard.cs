using System;

namespace behaviac
{
	// Token: 0x020030D1 RID: 12497
	public static class bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard
	{
		// Token: 0x06014A5B RID: 84571 RVA: 0x00637AC4 File Offset: 0x00635EC4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Tiaotiaowa/skill_tiaotiaowa_hard");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2 condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node = new Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2();
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node1 condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2 = new Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node1();
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node2.HasEvents());
			Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node3 action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node = new Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node3();
			action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
