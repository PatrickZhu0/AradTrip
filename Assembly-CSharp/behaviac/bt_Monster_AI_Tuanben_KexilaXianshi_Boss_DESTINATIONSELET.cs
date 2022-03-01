using System;

namespace behaviac
{
	// Token: 0x02003A84 RID: 14980
	public static class bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET
	{
		// Token: 0x06015CCF RID: 89295 RVA: 0x006966D8 File Offset: 0x00694AD8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/KexilaXianshi_Boss_DESTINATIONSELET");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node7 parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node = new Parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node7();
			parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetId(7);
			bt.AddChild(parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(8);
			parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node15 condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node = new Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node15();
			condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetId(15);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node64 condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2 = new Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node64();
			condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2.SetId(64);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node10 action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node = new Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node10();
			action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.HasEvents());
			parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(14);
			parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node79 condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node3 = new Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node79();
			condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node3.SetId(79);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node0 action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2 = new Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node0();
			action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2.SetId(0);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node2.HasEvents());
			parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node.HasEvents());
			return true;
		}
	}
}
