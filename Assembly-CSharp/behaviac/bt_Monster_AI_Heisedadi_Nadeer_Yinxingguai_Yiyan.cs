using System;

namespace behaviac
{
	// Token: 0x02003550 RID: 13648
	public static class bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan
	{
		// Token: 0x060152E0 RID: 86752 RVA: 0x006622B0 File Offset: 0x006606B0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Nadeer_Yinxingguai_Yiyan");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(103);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node104 condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node = new Condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node104();
			condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node.SetId(104);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node105 action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node = new Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node105();
			action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node.SetId(105);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node106 action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node2 = new Action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node106();
			action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node2.SetId(106);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
