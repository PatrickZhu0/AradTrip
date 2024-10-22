﻿using System;

namespace behaviac
{
	// Token: 0x02002D52 RID: 11602
	public static class bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS
	{
		// Token: 0x06014389 RID: 82825 RVA: 0x006129D8 File Offset: 0x00610DD8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_YXG_Zhaohuan_JDYS");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node31 parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node = new Parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node31();
			parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetId(31);
			bt.AddChild(parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(7);
			parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3 condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node = new Condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3();
			condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents());
			SelectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node9 selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node = new SelectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node9();
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetClassNameString("SelectorProbability");
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetId(9);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.Initialize("Self.BTAgent::Action_GenRandom()");
			sequence.AddChild(selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node);
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node16 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node16();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetId(16);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(10);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(sequence2);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node0 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node0();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetId(0);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node25 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node25();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.SetId(25);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | sequence2.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node19 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node19();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.SetId(19);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2);
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(12);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.AddChild(sequence3);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node1 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node1();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.SetId(1);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.SetId(14);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node26 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node26();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.SetId(26);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.HasEvents() | sequence3.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node2.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node21 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node21();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.SetId(21);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3);
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(2);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.AddChild(sequence4);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node7 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node7.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node7.SetId(4);
			sequence4.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node7.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8.SetId(5);
			sequence4.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node27 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node9 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node27();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node9.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node9.SetId(27);
			sequence4.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node9);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node9.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.HasEvents() | sequence4.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node22 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node22();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.SetId(22);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4);
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(6);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.AddChild(sequence5);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node10 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node10.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node10.SetId(8);
			sequence5.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node10);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node10.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11.SetId(13);
			sequence5.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node28 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node12 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node28();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node12.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node12.SetId(28);
			sequence5.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node12);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node12.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.HasEvents() | sequence5.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node4.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node23 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node23();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.SetId(23);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5);
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(15);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.AddChild(sequence6);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13.SetId(17);
			sequence6.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node29 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node29();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14.SetId(29);
			sequence6.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.HasEvents() | sequence6.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node24 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node24();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.SetId(24);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6);
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(18);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.AddChild(sequence7);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node20 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node15 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node20();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node15.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node15.SetId(20);
			sequence7.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node15);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node15.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node30 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node16 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node30();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node16.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node16.SetId(30);
			sequence7.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node16);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node16.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.HasEvents() | sequence7.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node6.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selectorProbability_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | sequence.HasEvents());
			Sequence sequence8 = new Sequence();
			sequence8.SetClassNameString("Sequence");
			sequence8.SetId(32);
			parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.AddChild(sequence8);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node33 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node33();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17.SetId(33);
			sequence8.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17);
			sequence8.SetHasEvents(sequence8.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node34 action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node18 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node34();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node18.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node18.SetId(34);
			sequence8.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node18);
			sequence8.SetHasEvents(sequence8.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node18.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents() | sequence8.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node.HasEvents());
			return true;
		}
	}
}
