using System;

namespace behaviac
{
	// Token: 0x02003AB6 RID: 15030
	public static class bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng
	{
		// Token: 0x06015D2E RID: 89390 RVA: 0x00697E9C File Offset: 0x0069629C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Kexila_Liuchengkongzhi_Emeng");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4 parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node = new Parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4();
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetId(4);
			bt.AddChild(parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(38);
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node39 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node39();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetId(39);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node85 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node85();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2.SetId(85);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node98 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node98();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3.SetId(98);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node56 action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node = new Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node56();
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetId(56);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node40 action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2 = new Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node40();
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2.SetId(40);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(7);
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node11 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node11();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5.SetId(11);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node12 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node12();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6.SetId(12);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6.HasEvents());
			Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node13 action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3 = new Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node13();
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3.SetId(13);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node14 action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4 = new Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node14();
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4.SetId(14);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(6);
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.AddChild(sequence3);
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node0 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node7 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node0();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node7.SetId(0);
			sequence3.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node7.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8.SetId(3);
			sequence3.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node1 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node1();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9.SetId(1);
			sequence3.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9.HasEvents());
			Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2 action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5 = new Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2();
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5.SetId(2);
			sequence3.AddChild(action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node5.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(5);
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.AddChild(sequence4);
			Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9 condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10 = new Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9();
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10.SetId(9);
			sequence4.AddChild(condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10.HasEvents());
			Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8 action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6 = new Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node8();
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6.SetId(8);
			sequence4.AddChild(action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node6.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node.HasEvents());
			return true;
		}
	}
}
