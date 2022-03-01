using System;

namespace behaviac
{
	// Token: 0x02002D63 RID: 11619
	public static class bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event
	{
		// Token: 0x060143A9 RID: 82857 RVA: 0x006138B4 File Offset: 0x00611CB4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/Chuanyuezhehuoyaotong_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node0 parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node = new Parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node0();
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetId(0);
			bt.AddChild(parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7 action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node = new Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7();
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node8 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node8();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10 action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2 = new Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10();
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2.SetId(10);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node2.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(3);
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.AddChild(sequence3);
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node11 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node11();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5.SetId(11);
			sequence3.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node12 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node12();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6.SetId(12);
			sequence3.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node13 action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3 = new Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node13();
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3.SetId(13);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node3.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(4);
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.AddChild(sequence4);
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node14 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node14();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7.SetId(14);
			sequence4.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node7.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node15 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node8 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node15();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node8.SetId(15);
			sequence4.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node8);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node8.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node16 action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4 = new Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node16();
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4.SetId(16);
			sequence4.AddChild(action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node4.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(17);
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.AddChild(sequence5);
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node18 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node18();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9.SetId(18);
			sequence5.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node19 condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10 = new Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node19();
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10.SetId(19);
			sequence5.AddChild(condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node10.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node20 action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5 = new Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node20();
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5.SetId(20);
			sequence5.AddChild(action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents() | sequence5.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node.HasEvents());
			return true;
		}
	}
}
