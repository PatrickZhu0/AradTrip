﻿using System;

namespace behaviac
{
	// Token: 0x02002CCB RID: 11467
	public static class bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action
	{
		// Token: 0x0601428A RID: 82570 RVA: 0x0060DDD0 File Offset: 0x0060C1D0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Tanglang_Fenshen_Action");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(3);
			bt.AddChild(sequence);
			SelectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node9 selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node = new SelectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node9();
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetClassNameString("SelectorProbability");
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetId(9);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.Initialize("Self.BTAgent::Action_GenRandom()");
			sequence.AddChild(selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node);
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node16 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node16();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetId(16);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(10);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node1 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node1();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetId(1);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2 = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node0 action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node = new Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node0();
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetId(0);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents() | sequence2.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.SetId(4);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2);
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(5);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.AddChild(sequence3);
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3 = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4 = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.SetId(6);
			sequence3.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7 action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7();
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.SetId(7);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.HasEvents() | sequence3.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node2.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node11 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node11();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.SetId(11);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3);
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(13);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.AddChild(sequence4);
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node12 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node5 = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node12();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node5.SetId(12);
			sequence4.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node5.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node14 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6 = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node14();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6.SetId(14);
			sequence4.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node15 action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3 = new Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node15();
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.SetId(15);
			sequence4.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.HasEvents() | sequence4.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node3.HasEvents());
			DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node22 decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4 = new DecoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node22();
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.SetClassNameString("DecoratorWeight");
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.SetId(22);
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.AddChild(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4);
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(23);
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.AddChild(sequence5);
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node17 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7 = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node17();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7.SetId(17);
			sequence5.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node7.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node24 condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8 = new Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node24();
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8.SetId(24);
			sequence5.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node25 action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4 = new Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node25();
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.SetId(25);
			sequence5.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.HasEvents());
			decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.SetHasEvents(decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.HasEvents() | sequence5.HasEvents());
			selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.SetHasEvents(selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents() | decoratorWeight_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node4.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selectorProbability_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
