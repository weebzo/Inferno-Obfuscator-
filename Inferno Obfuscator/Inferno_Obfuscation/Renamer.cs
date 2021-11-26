﻿using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200004B RID: 75
	internal class Renamer
	{
		// Token: 0x06000168 RID: 360 RVA: 0x0001C66C File Offset: 0x0001A86C
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("qwertyuiopasdfghjklzxcqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfg痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵hjklzxcvbnmqwertyuiopasdfghjklzxcvbnmvbnm", length)
			select s[Renamer.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0001C6B8 File Offset: 0x0001A8B8
		public static bool CanRename(TypeDef type)
		{
			bool isGlobalModuleType = type.IsGlobalModuleType;
			bool flag = isGlobalModuleType;
			bool flag10 = flag;
			bool result;
			if (flag10)
			{
				result = false;
			}
			else
			{
				try
				{
					bool flag2 = type.Namespace.Contains("My");
					bool flag3 = flag2;
					bool flag11 = flag3;
					if (flag11)
					{
						return false;
					}
				}
				catch
				{
				}
				bool isGlobalModuleType2 = type.IsGlobalModuleType;
				bool flag4 = isGlobalModuleType2;
				bool flag12 = flag4;
				if (flag12)
				{
					result = false;
				}
				else
				{
					bool flag5 = type.Name == "GeneratedInternalTypeHelper" || type.Name == "Resources" || type.Name == "Settings";
					bool flag6 = flag5;
					bool flag13 = flag6;
					if (flag13)
					{
						result = false;
					}
					else
					{
						bool flag7 = type.Interfaces.Count > 0;
						bool flag8 = flag7;
						bool flag14 = flag8;
						if (flag14)
						{
							result = false;
						}
						else
						{
							bool isSpecialName = type.IsSpecialName;
							bool flag9 = isSpecialName;
							bool flag15 = flag9;
							if (flag15)
							{
								result = false;
							}
							else
							{
								bool isRuntimeSpecialName = type.IsRuntimeSpecialName;
								result = !isRuntimeSpecialName;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0001C7E0 File Offset: 0x0001A9E0
		public static bool CanRename(EventDef ev)
		{
			bool isRuntimeSpecialName = ev.IsRuntimeSpecialName;
			return !isRuntimeSpecialName;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0001C800 File Offset: 0x0001AA00
		public static bool CanRename(MethodDef method)
		{
			bool isConstructor = method.IsConstructor;
			bool flag = isConstructor;
			bool flag4 = flag;
			bool result;
			if (flag4)
			{
				result = false;
			}
			else
			{
				bool isFamily = method.IsFamily;
				bool flag2 = isFamily;
				bool flag5 = flag2;
				if (flag5)
				{
					result = false;
				}
				else
				{
					bool isRuntimeSpecialName = method.IsRuntimeSpecialName;
					bool flag3 = isRuntimeSpecialName;
					bool flag6 = flag3;
					if (flag6)
					{
						result = false;
					}
					else
					{
						bool isForwarder = method.DeclaringType.IsForwarder;
						result = !isForwarder;
					}
				}
			}
			return result;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0001C878 File Offset: 0x0001AA78
		public static bool CanRename(FieldDef field)
		{
			bool flag = field.IsFamily || field.IsFamilyOrAssembly || field.IsPublic;
			bool flag2 = flag;
			bool flag7 = flag2;
			bool result;
			if (flag7)
			{
				result = false;
			}
			else
			{
				bool isRuntimeSpecialName = field.IsRuntimeSpecialName;
				bool flag3 = isRuntimeSpecialName;
				bool flag8 = flag3;
				if (flag8)
				{
					result = false;
				}
				else
				{
					bool flag4 = field.DeclaringType.IsSerializable && !field.IsNotSerialized;
					bool flag5 = flag4;
					bool flag9 = flag5;
					if (flag9)
					{
						result = false;
					}
					else
					{
						bool flag6 = field.IsLiteral && field.DeclaringType.IsEnum;
						result = !flag6;
					}
				}
			}
			return result;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0001C920 File Offset: 0x0001AB20
		public static string RandomOrNo()
		{
			string[] array = new string[]
			{
				"CausalityTraceLevel",
				"BitConverter",
				"UnhandledExceptionEventHandler",
				"PinnedBufferMemoryStream",
				"RichTextBoxScrollBars",
				"RichTextBoxSelectionAttribute",
				"RichTextBoxSelectionTypes",
				"RichTextBoxStreamType",
				"RichTextBoxWordPunctuations",
				"RightToLeft",
				"RTLAwareMessageBox",
				"SafeNativeMethods",
				"SaveFileDialog",
				"Screen",
				"ScreenOrientation",
				"ScrollableControl",
				"ScrollBar",
				"ScrollBarRenderer",
				"ScrollBars",
				"ScrollButton",
				"ScrollEventArgs",
				"ScrollEventHandler",
				"ScrollEventType",
				"ScrollOrientation",
				"ScrollProperties",
				"SearchDirectionHint",
				"SearchForVirtualItemEventArgs",
				"SearchForVirtualItemEventHandler",
				"SecurityIDType",
				"SelectedGridItemChangedEventArgs",
				"SelectedGridItemChangedEventHandler",
				"SelectionMode",
				"SelectionRange",
				"SelectionRangeConverter",
				"SendKeys",
				"Shortcut",
				"SizeGripStyle",
				"SortOrder",
				"SpecialFolderEnumConverter",
				"SplitContainer",
				"Splitter",
				"SplitterCancelEventArgs",
				"SplitterCancelEventHandler",
				"SplitterEventArgs",
				"SplitterEventHandler",
				"SplitterPanel",
				"StatusBar",
				"StatusBarDrawItemEventArgs",
				"StatusBarDrawItemEventHandler",
				"StatusBarPanel",
				"StatusBarPanelAutoSize",
				"StatusBarPanelBorderStyle",
				"StatusBarPanelClickEventArgs",
				"StatusBarPanelClickEventHandler",
				"StatusBarPanelStyle",
				"StatusStrip",
				"StringSorter",
				"StringSource",
				"StructFormat",
				"SystemInformation",
				"SystemParameter",
				"TabAlignment",
				"TabAppearance",
				"TabControl",
				"TabControlAction",
				"TabControlCancelEventArgs",
				"TabControlCancelEventHandler",
				"TabControlEventArgs",
				"TabControlEventHandler",
				"TabDrawMode",
				"TableLayoutPanel",
				"TableLayoutControlCollection",
				"TableLayoutPanelCellBorderStyle",
				"TableLayoutPanelCellPosition",
				"TableLayoutPanelCellPositionTypeConverter",
				"TableLayoutPanelGrowStyle",
				"TableLayoutSettings",
				"SizeType",
				"ColumnStyle",
				"RowStyle",
				"TableLayoutStyle",
				"TableLayoutStyleCollection",
				"TableLayoutCellPaintEventArgs",
				"TableLayoutCellPaintEventHandler",
				"TableLayoutColumnStyleCollection",
				"TableLayoutRowStyleCollection",
				"TabPage",
				"TabRenderer",
				"TabSizeMode",
				"TextBox",
				"TextBoxAutoCompleteSourceConverter",
				"TextBoxBase",
				"TextBoxRenderer",
				"TextDataFormat",
				"TextImageRelation",
				"ThreadExceptionDialog",
				"TickStyle",
				"ToolBar",
				"ToolBarAppearance",
				"ToolBarButton",
				"ToolBarButtonClickEventArgs",
				"ToolBarButtonClickEventHandler",
				"ToolBarButtonStyle",
				"ToolBarTextAlign",
				"ToolStrip",
				"CachedItemHdcInfo",
				"MouseHoverTimer",
				"ToolStripSplitStackDragDropHandler",
				"ToolStripArrowRenderEventArgs",
				"ToolStripArrowRenderEventHandler",
				"ToolStripButton",
				"ToolStripComboBox",
				"ToolStripControlHost",
				"ToolStripDropDown",
				"ToolStripDropDownCloseReason",
				"ToolStripDropDownClosedEventArgs",
				"ToolStripDropDownClosedEventHandler",
				"ToolStripDropDownClosingEventArgs",
				"ToolStripDropDownClosingEventHandler",
				"ToolStripDropDownDirection",
				"ToolStripDropDownButton",
				"ToolStripDropDownItem",
				"ToolStripDropDownItemAccessibleObject",
				"ToolStripDropDownMenu",
				"ToolStripDropTargetManager",
				"ToolStripHighContrastRenderer",
				"ToolStripGrip",
				"ToolStripGripDisplayStyle",
				"ToolStripGripRenderEventArgs",
				"ToolStripGripRenderEventHandler",
				"ToolStripGripStyle",
				"ToolStripItem",
				"ToolStripItemImageIndexer",
				"ToolStripItemInternalLayout",
				"ToolStripItemAlignment",
				"ToolStripItemClickedEventArgs",
				"ToolStripItemClickedEventHandler",
				"ToolStripItemCollection",
				"ToolStripItemDisplayStyle",
				"ToolStripItemEventArgs",
				"ToolStripItemEventHandler",
				"ToolStripItemEventType",
				"ToolStripItemImageRenderEventArgs",
				"ToolStripItemImageRenderEventHandler",
				"ToolStripItemImageScaling",
				"ToolStripItemOverflow",
				"ToolStripItemPlacement",
				"ToolStripItemRenderEventArgs",
				"ToolStripItemRenderEventHandler",
				"ToolStripItemStates",
				"ToolStripItemTextRenderEventArgs",
				"ToolStripItemTextRenderEventHandler",
				"ToolStripLabel",
				"ToolStripLayoutStyle",
				"ToolStripManager",
				"ToolStripCustomIComparer",
				"MergeHistory",
				"MergeHistoryItem",
				"ToolStripManagerRenderMode",
				"ToolStripMenuItem",
				"MenuTimer",
				"ToolStripMenuItemInternalLayout",
				"ToolStripOverflow",
				"ToolStripOverflowButton",
				"ToolStripContainer",
				"ToolStripContentPanel",
				"ToolStripPanel",
				"ToolStripPanelCell",
				"ToolStripPanelRenderEventArgs",
				"ToolStripPanelRenderEventHandler",
				"ToolStripContentPanelRenderEventArgs",
				"ToolStripContentPanelRenderEventHandler",
				"ToolStripPanelRow",
				"ToolStripPointType",
				"ToolStripProfessionalRenderer",
				"ToolStripProfessionalLowResolutionRenderer",
				"ToolStripProgressBar",
				"ToolStripRenderer",
				"ToolStripRendererSwitcher",
				"ToolStripRenderEventArgs",
				"ToolStripRenderEventHandler",
				"ToolStripRenderMode",
				"ToolStripScrollButton",
				"ToolStripSeparator",
				"ToolStripSeparatorRenderEventArgs",
				"ToolStripSeparatorRenderEventHandler",
				"ToolStripSettings",
				"ToolStripSettingsManager",
				"ToolStripSplitButton",
				"ToolStripSplitStackLayout",
				"ToolStripStatusLabel",
				"ToolStripStatusLabelBorderSides",
				"ToolStripSystemRenderer",
				"ToolStripTextBox",
				"ToolStripTextDirection",
				"ToolStripLocationCancelEventArgs",
				"ToolStripLocationCancelEventHandler",
				"ToolTip",
				"ToolTipIcon",
				"TrackBar",
				"TrackBarRenderer",
				"TreeNode",
				"TreeNodeMouseClickEventArgs",
				"TreeNodeMouseClickEventHandler",
				"TreeNodeCollection",
				"TreeNodeConverter",
				"TreeNodeMouseHoverEventArgs",
				"TreeNodeMouseHoverEventHandler",
				"TreeNodeStates",
				"TreeView",
				"TreeViewAction",
				"TreeViewCancelEventArgs",
				"TreeViewCancelEventHandler",
				"TreeViewDrawMode",
				"TreeViewEventArgs",
				"TreeViewEventHandler",
				"TreeViewHitTestInfo",
				"TreeViewHitTestLocations",
				"TreeViewImageIndexConverter",
				"TreeViewImageKeyConverter",
				"Triangle",
				"TriangleDirection",
				"TypeValidationEventArgs",
				"TypeValidationEventHandler",
				"UICues",
				"UICuesEventArgs",
				"UICuesEventHandler",
				"UpDownBase",
				"UpDownEventArgs",
				"UpDownEventHandler",
				"UserControl",
				"ValidationConstraints",
				"View",
				"VScrollBar",
				"VScrollProperties",
				"WebBrowser",
				"WebBrowserEncryptionLevel",
				"WebBrowserReadyState",
				"WebBrowserRefreshOption",
				"WebBrowserBase",
				"WebBrowserContainer",
				"WebBrowserDocumentCompletedEventHandler",
				"WebBrowserDocumentCompletedEventArgs",
				"WebBrowserHelper",
				"WebBrowserNavigatedEventHandler",
				"WebBrowserNavigatedEventArgs",
				"WebBrowserNavigatingEventHandler",
				"WebBrowserNavigatingEventArgs",
				"WebBrowserProgressChangedEventHandler",
				"WebBrowserProgressChangedEventArgs",
				"WebBrowserSiteBase",
				"WebBrowserUriTypeConverter",
				"WinCategoryAttribute",
				"WindowsFormsSection",
				"WindowsFormsSynchronizationContext",
				"IntSecurity",
				"WindowsFormsUtils",
				"IComponentEditorPageSite",
				"LayoutSettings",
				"PageSetupDialog",
				"PrintControllerWithStatusDialog",
				"PrintDialog",
				"PrintPreviewControl",
				"PrintPreviewDialog",
				"TextFormatFlags",
				"TextRenderer",
				"WindowsGraphicsWrapper",
				"SRDescriptionAttribute",
				"SRCategoryAttribute",
				"SR",
				"VisualStyleElement",
				"VisualStyleInformation",
				"VisualStyleRenderer",
				"VisualStyleState",
				"ComboBoxState",
				"CheckBoxState",
				"GroupBoxState",
				"HeaderItemState",
				"PushButtonState",
				"RadioButtonState",
				"ScrollBarArrowButtonState",
				"ScrollBarState",
				"ScrollBarSizeBoxState",
				"TabItemState",
				"TextBoxState",
				"ToolBarState",
				"TrackBarThumbState",
				"BackgroundType",
				"BorderType",
				"ImageOrientation",
				"SizingType",
				"FillType",
				"HorizontalAlign",
				"ContentAlignment",
				"VerticalAlignment",
				"OffsetType",
				"IconEffect",
				"TextShadowType",
				"GlyphType",
				"ImageSelectType",
				"TrueSizeScalingType",
				"GlyphFontSizingType",
				"ColorProperty",
				"EnumProperty",
				"FilenameProperty",
				"FontProperty",
				"IntegerProperty",
				"PointProperty",
				"MarginProperty",
				"StringProperty",
				"BooleanProperty",
				"Edges",
				"EdgeStyle",
				"EdgeEffects",
				"TextMetrics",
				"TextMetricsPitchAndFamilyValues",
				"TextMetricsCharacterSet",
				"HitTestOptions",
				"HitTestCode",
				"ThemeSizeType",
				"VisualStyleDocProperty",
				"VisualStyleSystemProperty",
				"ArrayElementGridEntry",
				"CategoryGridEntry",
				"DocComment",
				"DropDownButton",
				"DropDownButtonAdapter",
				"GridEntry",
				"AttributeTypeSorter",
				"GridEntryRecreateChildrenEventHandler",
				"GridEntryRecreateChildrenEventArgs",
				"GridEntryCollection",
				"GridErrorDlg",
				"GridToolTip",
				"HotCommands",
				"ImmutablePropertyDescriptorGridEntry",
				"IRootGridEntry",
				"MergePropertyDescriptor",
				"MultiPropertyDescriptorGridEntry",
				"MultiSelectRootGridEntry",
				"PropertiesTab",
				"PropertyDescriptorGridEntry",
				"PropertyGridCommands",
				"PropertyGridView",
				"SingleSelectRootGridEntry",
				"ComponentEditorForm",
				"ComponentEditorPage",
				"EventsTab",
				"IUIService",
				"IWindowsFormsEditorService",
				"PropertyTab",
				"ToolStripItemDesignerAvailability",
				"ToolStripItemDesignerAvailabilityAttribute",
				"WindowsFormsComponentEditor",
				"BaseCAMarshaler",
				"Com2AboutBoxPropertyDescriptor",
				"Com2ColorConverter",
				"Com2ComponentEditor",
				"Com2DataTypeToManagedDataTypeConverter",
				"Com2Enum",
				"Com2EnumConverter",
				"Com2ExtendedBrowsingHandler",
				"Com2ExtendedTypeConverter",
				"Com2FontConverter",
				"Com2ICategorizePropertiesHandler",
				"Com2IDispatchConverter",
				"Com2IManagedPerPropertyBrowsingHandler",
				"Com2IPerPropertyBrowsingHandler",
				"Com2IProvidePropertyBuilderHandler",
				"Com2IVsPerPropertyBrowsingHandler",
				"Com2PictureConverter",
				"Com2Properties",
				"Com2PropertyBuilderUITypeEditor",
				"Com2PropertyDescriptor",
				"GetAttributesEvent",
				"Com2EventHandler",
				"GetAttributesEventHandler",
				"GetNameItemEvent",
				"GetNameItemEventHandler",
				"DynamicMetaObjectProviderDebugView",
				"ExpressionTreeCallRewriter",
				"ICSharpInvokeOrInvokeMemberBinder",
				"ResetBindException",
				"RuntimeBinder",
				"RuntimeBinderController",
				"RuntimeBinderException",
				"RuntimeBinderInternalCompilerException",
				"SpecialNames",
				"SymbolTable",
				"RuntimeBinderExtensions",
				"NameManager",
				"Name",
				"NameTable",
				"OperatorKind",
				"PredefinedName",
				"PredefinedType",
				"TokenFacts",
				"TokenKind",
				"OutputContext",
				"UNSAFESTATES",
				"CheckedContext",
				"BindingFlag",
				"ExpressionBinder",
				"BinOpKind",
				"BinOpMask",
				"CandidateFunctionMember",
				"ConstValKind",
				"CONSTVAL",
				"ConstValFactory",
				"ConvKind",
				"CONVERTTYPE",
				"BetterType",
				"ListExtensions",
				"CConversions",
				"Operators",
				"UdConvInfo",
				"ArgInfos",
				"BodyType",
				"ConstCastResult",
				"AggCastResult",
				"UnaryOperatorSignatureFindResult",
				"UnaOpKind",
				"UnaOpMask",
				"OpSigFlags",
				"LiftFlags",
				"CheckLvalueKind",
				"BinOpFuncKind",
				"UnaOpFuncKind",
				"ExpressionKind",
				"ExpressionKindExtensions",
				"EXPRExtensions",
				"ExprFactory",
				"EXPRFLAG",
				"FileRecord",
				"FUNDTYPE",
				"GlobalSymbolContext",
				"InputFile",
				"LangCompiler",
				"MemLookFlags",
				"MemberLookup",
				"CMemberLookupResults",
				"mdToken",
				"CorAttributeTargets",
				"MethodKindEnum",
				"MethodTypeInferrer",
				"NameGenerator",
				"CNullable",
				"NullableCallLiftKind",
				"CONSTRESKIND",
				"LambdaParams",
				"TypeOrSimpleNameResolution",
				"InitializerKind",
				"ConstantStringConcatenation",
				"ForeachKind",
				"PREDEFATTR",
				"PREDEFMETH",
				"PREDEFPROP",
				"MethodRequiredEnum",
				"MethodCallingConventionEnum",
				"MethodSignatureEnum",
				"PredefinedMethodInfo",
				"PredefinedPropertyInfo",
				"PredefinedMembers",
				"ACCESSERROR",
				"CSemanticChecker",
				"SubstTypeFlags",
				"SubstContext",
				"CheckConstraintsFlags",
				"TypeBind",
				"UtilityTypeExtensions",
				"SymWithType",
				"MethPropWithType",
				"MethWithType",
				"PropWithType",
				"EventWithType",
				"FieldWithType",
				"MethPropWithInst",
				"MethWithInst",
				"AggregateDeclaration",
				"Declaration",
				"GlobalAttributeDeclaration",
				"ITypeOrNamespace",
				"AggregateSymbol",
				"AssemblyQualifiedNamespaceSymbol",
				"EventSymbol",
				"FieldSymbol",
				"IndexerSymbol",
				"LabelSymbol",
				"LocalVariableSymbol",
				"MethodOrPropertySymbol",
				"MethodSymbol",
				"InterfaceImplementationMethodSymbol",
				"IteratorFinallyMethodSymbol",
				"MiscSymFactory",
				"NamespaceOrAggregateSymbol",
				"NamespaceSymbol",
				"ParentSymbol",
				"PropertySymbol",
				"Scope",
				"KAID",
				"ACCESS",
				"AggKindEnum",
				"ARRAYMETHOD",
				"SpecCons",
				"Symbol",
				"SymbolExtensions",
				"SymFactory",
				"SymFactoryBase",
				"SYMKIND",
				"SynthAggKind",
				"SymbolLoader",
				"AidContainer",
				"BSYMMGR",
				"symbmask_t",
				"SYMTBL",
				"TransparentIdentifierMemberSymbol",
				"TypeParameterSymbol",
				"UnresolvedAggregateSymbol",
				"VariableSymbol",
				"EXPRARRAYINDEX",
				"EXPRARRINIT",
				"EXPRARRAYLENGTH",
				"EXPRASSIGNMENT",
				"EXPRBINOP",
				"EXPRBLOCK",
				"EXPRBOUNDLAMBDA",
				"EXPRCALL",
				"EXPRCAST",
				"EXPRCLASS",
				"EXPRMULTIGET",
				"EXPRMULTI",
				"EXPRCONCAT",
				"EXPRQUESTIONMARK",
				"EXPRCONSTANT",
				"EXPREVENT",
				"EXPR",
				"ExpressionIterator",
				"EXPRFIELD",
				"EXPRFIELDINFO",
				"EXPRHOISTEDLOCALEXPR",
				"EXPRLIST",
				"EXPRLOCAL",
				"EXPRMEMGRP",
				"EXPRMETHODINFO",
				"EXPRFUNCPTR",
				"EXPRNamedArgumentSpecification",
				"EXPRPROP",
				"EXPRPropertyInfo",
				"EXPRRETURN",
				"EXPRSTMT",
				"EXPRWRAP",
				"EXPRTHISPOINTER",
				"EXPRTYPEARGUMENTS",
				"EXPRTYPEOF",
				"EXPRTYPEORNAMESPACE",
				"EXPRUNARYOP",
				"EXPRUNBOUNDLAMBDA",
				"EXPRUSERDEFINEDCONVERSION",
				"EXPRUSERLOGOP",
				"EXPRZEROINIT",
				"ExpressionTreeRewriter",
				"ExprVisitorBase",
				"AggregateType",
				"ArgumentListType",
				"ArrayType",
				"BoundLambdaType",
				"ErrorType",
				"MethodGroupType",
				"NullableType",
				"NullType",
				"OpenTypePlaceholderType",
				"ParameterModifierType",
				"PointerType",
				"PredefinedTypes",
				"PredefinedTypeFacts",
				"CType",
				"TypeArray",
				"TypeFactory",
				"TypeManager",
				"TypeParameterType",
				"KeyPair`2",
				"TypeTable",
				"VoidType",
				"CError",
				"CParameterizedError",
				"CErrorFactory",
				"ErrorFacts",
				"ErrArgKind",
				"ErrArgFlags",
				"SymWithTypeMemo",
				"MethPropWithInstMemo",
				"ErrArg",
				"ErrArgRef",
				"ErrArgRefOnly",
				"ErrArgNoRef",
				"ErrArgIds",
				"ErrArgSymKind",
				"ErrorHandling",
				"IErrorSink",
				"MessageID",
				"UserStringBuilder",
				"CController",
				"<Cons>d__10`1",
				"<Cons>d__11`1",
				"DynamicProperty",
				"DynamicDebugViewEmptyException",
				"<>c__DisplayClass20_0",
				"ExpressionEXPR",
				"ArgumentObject",
				"NameHashKey",
				"<>c__DisplayClass18_0",
				"<>c__DisplayClass18_1",
				"<>c__DisplayClass43_0",
				"<>c__DisplayClass45_0",
				"KnownName",
				"BinOpArgInfo",
				"BinOpSig",
				"BinOpFullSig",
				"ConversionFunc",
				"ExplicitConversion",
				"PfnBindBinOp",
				"PfnBindUnaOp",
				"GroupToArgsBinder",
				"GroupToArgsBinderResult",
				"ImplicitConversion",
				"UnaOpSig",
				"UnaOpFullSig",
				"OPINFO",
				"<ToEnumerable>d__1",
				"CMethodIterator",
				"NewInferenceResult",
				"Dependency",
				"<InterfaceAndBases>d__0",
				"<AllConstraintInterfaces>d__1",
				"<TypeAndBaseClasses>d__2",
				"<TypeAndBaseClassInterfaces>d__3",
				"<AllPossibleInterfaces>d__4",
				"<Children>d__0",
				"Kind",
				"TypeArrayKey",
				"Key",
				"PredefinedTypeInfo",
				"StdTypeVarColl",
				"<>c__DisplayClass71_0",
				"__StaticArrayInitTypeSize=104",
				"__StaticArrayInitTypeSize=169",
				"SNINativeMethodWrapper",
				"QTypes",
				"ProviderEnum",
				"IOType",
				"ConsumerNumber",
				"SqlAsyncCallbackDelegate",
				"ConsumerInfo",
				"SNI_Error",
				"Win32NativeMethods",
				"NativeOledbWrapper",
				"AdalException",
				"ADALNativeWrapper",
				"Sni_Consumer_Info",
				"SNI_ConnWrapper",
				"SNI_Packet_IOType",
				"ConsumerNum",
				"$ArrayType$$$BY08$$CBG",
				"_GUID",
				"SNI_CLIENT_CONSUMER_INFO",
				"IUnknown",
				"__s_GUID",
				"IChapteredRowset",
				"_FILETIME",
				"ProviderNum",
				"ITransactionLocal",
				"SNI_ERROR",
				"$ArrayType$$$BY08G",
				"BOID",
				"ModuleLoadException",
				"ModuleLoadExceptionHandlerException",
				"ModuleUninitializer",
				"LanguageSupport",
				"gcroot<System::String ^>",
				"$ArrayType$$$BY00Q6MPBXXZ",
				"Progress",
				"$ArrayType$$$BY0A@P6AXXZ",
				"$ArrayType$$$BY0A@P6AHXZ",
				"__enative_startup_state",
				"TriBool",
				"ICLRRuntimeHost",
				"ThisModule",
				"_EXCEPTION_POINTERS",
				"Bid",
				"SqlDependencyProcessDispatcher",
				"BidIdentityAttribute",
				"BidMetaTextAttribute",
				"BidMethodAttribute",
				"BidArgumentTypeAttribute",
				"ExtendedClrTypeCode",
				"ITypedGetters",
				"ITypedGettersV3",
				"ITypedSetters",
				"ITypedSettersV3",
				"MetaDataUtilsSmi",
				"SmiConnection",
				"SmiContext",
				"SmiContextFactory",
				"SmiEventSink",
				"SmiEventSink_Default",
				"SmiEventSink_DeferedProcessing",
				"SmiEventStream",
				"SmiExecuteType",
				"SmiGettersStream",
				"SmiLink",
				"SmiMetaData",
				"SmiExtendedMetaData",
				"SmiParameterMetaData",
				"SmiStorageMetaData",
				"SmiQueryMetaData",
				"SmiRecordBuffer",
				"SmiRequestExecutor",
				"SmiSettersStream",
				"SmiStream",
				"SmiXetterAccessMap",
				"SmiXetterTypeCode",
				"SqlContext",
				"SqlDataRecord",
				"SqlPipe",
				"SqlTriggerContext",
				"ValueUtilsSmi",
				"SqlClientWrapperSmiStream",
				"SqlClientWrapperSmiStreamChars",
				"IBinarySerialize",
				"InvalidUdtException",
				"SqlFacetAttribute",
				"DataAccessKind",
				"SystemDataAccessKind",
				"SqlFunctionAttribute",
				"SqlMetaData",
				"SqlMethodAttribute",
				"FieldInfoEx",
				"BinaryOrderedUdtNormalizer",
				"Normalizer",
				"BooleanNormalizer",
				"SByteNormalizer",
				"ByteNormalizer",
				"ShortNormalizer",
				"UShortNormalizer",
				"IntNormalizer",
				"UIntNormalizer",
				"LongNormalizer",
				"ULongNormalizer",
				"FloatNormalizer",
				"DoubleNormalizer",
				"SqlProcedureAttribute",
				"SerializationHelperSql9",
				"Serializer",
				"NormalizedSerializer",
				"BinarySerializeSerializer",
				"DummyStream",
				"SqlTriggerAttribute",
				"SqlUserDefinedAggregateAttribute",
				"SqlUserDefinedTypeAttribute",
				"TriggerAction",
				"MemoryRecordBuffer",
				"SmiPropertySelector",
				"SmiMetaDataPropertyCollection",
				"SmiMetaDataProperty",
				"SmiUniqueKeyProperty",
				"SmiOrderProperty",
				"SmiDefaultFieldsProperty",
				"SmiTypedGetterSetter",
				"SqlRecordBuffer",
				"BaseTreeIterator",
				"DataDocumentXPathNavigator",
				"DataPointer",
				"DataSetMapper",
				"IXmlDataVirtualNode",
				"BaseRegionIterator",
				"RegionIterator",
				"TreeIterator",
				"ElementState",
				"XmlBoundElement",
				"XmlDataDocument",
				"XmlDataImplementation",
				"XPathNodePointer",
				"AcceptRejectRule",
				"InternalDataCollectionBase",
				"TypedDataSetGenerator",
				"StrongTypingException",
				"TypedDataSetGeneratorException",
				"ColumnTypeConverter",
				"CommandBehavior",
				"CommandType",
				"KeyRestrictionBehavior",
				"ConflictOption",
				"ConnectionState",
				"Constraint",
				"ConstraintCollection",
				"ConstraintConverter",
				"ConstraintEnumerator",
				"ForeignKeyConstraintEnumerator",
				"ChildForeignKeyConstraintEnumerator",
				"ParentForeignKeyConstraintEnumerator",
				"DataColumn",
				"AutoIncrementValue",
				"AutoIncrementInt64",
				"AutoIncrementBigInteger",
				"DataColumnChangeEventArgs",
				"DataColumnChangeEventHandler",
				"DataColumnCollection",
				"DataColumnPropertyDescriptor",
				"DataError",
				"DataException",
				"ConstraintException",
				"DeletedRowInaccessibleException",
				"DuplicateNameException",
				"InRowChangingEventException",
				"InvalidConstraintException",
				"MissingPrimaryKeyException",
				"NoNullAllowedException",
				"ReadOnlyException",
				"RowNotInTableException",
				"VersionNotFoundException",
				"ExceptionBuilder",
				"DataKey",
				"DataRelation",
				"DataRelationCollection",
				"DataRelationPropertyDescriptor",
				"DataRow",
				"DataRowBuilder",
				"DataRowAction",
				"DataRowChangeEventArgs",
				"DataRowChangeEventHandler",
				"DataRowCollection",
				"DataRowCreatedEventHandler",
				"DataSetClearEventhandler",
				"DataRowState",
				"DataRowVersion",
				"DataRowView",
				"SerializationFormat",
				"DataSet",
				"DataSetSchemaImporterExtension",
				"DataSetDateTime",
				"DataSysDescriptionAttribute",
				"DataTable",
				"DataTableClearEventArgs",
				"DataTableClearEventHandler",
				"DataTableCollection",
				"DataTableNewRowEventArgs",
				"DataTableNewRowEventHandler",
				"DataTablePropertyDescriptor",
				"DataTableReader",
				"DataTableReaderListener",
				"DataTableTypeConverter",
				"DataView",
				"DataViewListener",
				"DataViewManager",
				"DataViewManagerListItemTypeDescriptor",
				"DataViewRowState",
				"DataViewSetting",
				"DataViewSettingCollection",
				"DBConcurrencyException",
				"DbType",
				"DefaultValueTypeConverter",
				"FillErrorEventArgs",
				"FillErrorEventHandler",
				"AggregateNode",
				"BinaryNode",
				"LikeNode",
				"ConstNode",
				"DataExpression",
				"ExpressionNode",
				"ExpressionParser",
				"Tokens",
				"OperatorInfo",
				"InvalidExpressionException",
				"EvaluateException",
				"SyntaxErrorException",
				"ExprException",
				"FunctionNode",
				"FunctionId",
				"Function",
				"IFilter",
				"LookupNode",
				"NameNode",
				"UnaryNode",
				"ZeroOpNode",
				"ForeignKeyConstraint",
				"IColumnMapping",
				"IColumnMappingCollection",
				"IDataAdapter",
				"IDataParameter",
				"IDataParameterCollection",
				"IDataReader",
				"IDataRecord",
				"IDbCommand",
				"IDbConnection",
				"IDbDataAdapter",
				"IDbDataParameter",
				"IDbTransaction",
				"IsolationLevel",
				"ITableMapping",
				"ITableMappingCollection",
				"LoadOption",
				"MappingType",
				"MergeFailedEventArgs",
				"MergeFailedEventHandler",
				"Merger",
				"MissingMappingAction",
				"MissingSchemaAction",
				"OperationAbortedException",
				"ParameterDirection",
				"PrimaryKeyTypeConverter",
				"PropertyCollection",
				"RBTreeError",
				"TreeAccessMethod",
				"RBTree`1",
				"RecordManager",
				"StatementCompletedEventArgs",
				"StatementCompletedEventHandler",
				"RelatedView",
				"RelationshipConverter",
				"Rule",
				"SchemaSerializationMode",
				"SchemaType",
				"IndexField",
				"Index",
				"Listeners`1",
				"SimpleType",
				"LocalDBAPI",
				"LocalDBInstanceElement",
				"LocalDBInstancesCollection",
				"LocalDBConfigurationSection",
				"SqlDbType",
				"StateChangeEventArgs",
				"StateChangeEventHandler",
				"StatementType",
				"UniqueConstraint",
				"UpdateRowSource",
				"UpdateStatus",
				"XDRSchema",
				"XmlDataLoader",
				"XMLDiffLoader",
				"XmlReadMode",
				"SchemaFormat",
				"XmlTreeGen",
				"NewDiffgramGen",
				"XmlDataTreeWriter",
				"DataTextWriter",
				"DataTextReader",
				"XMLSchema",
				"ConstraintTable",
				"XSDSchema",
				"XmlIgnoreNamespaceReader",
				"XmlToDatasetMap",
				"XmlWriteMode",
				"SqlEventSource",
				"SqlDataSourceEnumerator",
				"SqlGenericUtil",
				"SqlNotificationRequest",
				"INullable",
				"SqlBinary",
				"SqlBoolean",
				"SqlByte",
				"SqlBytesCharsState",
				"SqlBytes",
				"StreamOnSqlBytes",
				"SqlChars",
				"StreamOnSqlChars",
				"SqlStreamChars",
				"SqlDateTime",
				"SqlDecimal",
				"SqlDouble",
				"SqlFileStream",
				"UnicodeString",
				"SecurityQualityOfService",
				"FileFullEaInformation",
				"SqlGuid",
				"SqlInt16",
				"SqlInt32",
				"SqlInt64",
				"SqlMoney",
				"SQLResource",
				"SqlSingle",
				"SqlCompareOptions",
				"SqlString",
				"SqlTypesSchemaImporterExtensionHelper",
				"TypeCharSchemaImporterExtension",
				"TypeNCharSchemaImporterExtension",
				"TypeVarCharSchemaImporterExtension",
				"TypeNVarCharSchemaImporterExtension",
				"TypeTextSchemaImporterExtension",
				"TypeNTextSchemaImporterExtension",
				"TypeVarBinarySchemaImporterExtension",
				"TypeBinarySchemaImporterExtension",
				"TypeVarImageSchemaImporterExtension",
				"TypeDecimalSchemaImporterExtension",
				"TypeNumericSchemaImporterExtension",
				"TypeBigIntSchemaImporterExtension",
				"TypeIntSchemaImporterExtension",
				"TypeSmallIntSchemaImporterExtension",
				"TypeTinyIntSchemaImporterExtension",
				"TypeBitSchemaImporterExtension",
				"TypeFloatSchemaImporterExtension",
				"TypeRealSchemaImporterExtension",
				"TypeDateTimeSchemaImporterExtension",
				"TypeSmallDateTimeSchemaImporterExtension",
				"TypeMoneySchemaImporterExtension",
				"TypeSmallMoneySchemaImporterExtension",
				"TypeUniqueIdentifierSchemaImporterExtension",
				"EComparison",
				"StorageState",
				"SqlTypeException",
				"SqlNullValueException",
				"SqlTruncateException",
				"SqlNotFilledException",
				"SqlAlreadyFilledException",
				"SQLDebug",
				"SqlXml",
				"SqlXmlStreamWrapper",
				"SqlClientEncryptionAlgorithmFactoryList",
				"SqlSymmetricKeyCache",
				"SqlColumnEncryptionKeyStoreProvider",
				"SqlColumnEncryptionCertificateStoreProvider",
				"SqlColumnEncryptionCngProvider",
				"SqlColumnEncryptionCspProvider",
				"SqlAeadAes256CbcHmac256Algorithm",
				"SqlAeadAes256CbcHmac256Factory",
				"SqlAeadAes256CbcHmac256EncryptionKey",
				"SqlAes256CbcAlgorithm",
				"SqlAes256CbcFactory",
				"SqlClientEncryptionAlgorithm",
				"SqlClientEncryptionAlgorithmFactory",
				"SqlClientEncryptionType",
				"SqlClientSymmetricKey",
				"SqlSecurityUtility",
				"SqlQueryMetadataCache",
				"ApplicationIntent",
				"SqlCredential",
				"SqlConnectionPoolKey",
				"AssemblyCache",
				"OnChangeEventHandler",
				"SqlRowsCopiedEventArgs",
				"SqlRowsCopiedEventHandler",
				"SqlBuffer",
				"_ColumnMapping",
				"Row",
				"BulkCopySimpleResultSet",
				"SqlBulkCopy",
				"SqlBulkCopyColumnMapping",
				"SqlBulkCopyColumnMappingCollection",
				"SqlBulkCopyOptions",
				"SqlCachedBuffer",
				"SqlClientFactory",
				"SqlClientMetaDataCollectionNames",
				"SqlClientPermission",
				"SqlClientPermissionAttribute",
				"SqlCommand",
				"SqlCommandBuilder",
				"SqlCommandSet",
				"SqlConnection",
				"SQLDebugging",
				"ISQLDebug",
				"SqlDebugContext",
				"MEMMAP",
				"SqlConnectionFactory",
				"SqlPerformanceCounters",
				"SqlConnectionPoolGroupProviderInfo",
				"SqlConnectionPoolProviderInfo",
				"SqlConnectionString",
				"SqlConnectionStringBuilder",
				"SqlConnectionTimeoutErrorPhase",
				"SqlConnectionInternalSourceType",
				"SqlConnectionTimeoutPhaseDuration",
				"SqlConnectionTimeoutErrorInternal",
				"SqlDataAdapter",
				"SqlDataReader",
				"SqlDataReaderSmi",
				"SqlDelegatedTransaction",
				"SqlDependency",
				"SqlDependencyPerAppDomainDispatcher",
				"SqlNotification",
				"MetaType",
				"TdsDateTime",
				"SqlError",
				"SqlErrorCollection",
				"SqlException",
				"SqlInfoMessageEventArgs",
				"SqlInfoMessageEventHandler",
				"SqlInternalConnection",
				"SqlInternalConnectionSmi",
				"SessionStateRecord",
				"SessionData",
				"SqlInternalConnectionTds",
				"ServerInfo",
				"TransactionState",
				"TransactionType",
				"SqlInternalTransaction",
				"SqlMetaDataFactory",
				"SqlNotificationEventArgs",
				"SqlNotificationInfo",
				"SqlNotificationSource",
				"SqlNotificationType",
				"DataFeed",
				"StreamDataFeed",
				"TextDataFeed",
				"XmlDataFeed",
				"SqlParameter",
				"SqlParameterCollection",
				"SqlReferenceCollection",
				"SqlRowUpdatedEventArgs",
				"SqlRowUpdatedEventHandler",
				"SqlRowUpdatingEventArgs",
				"SqlRowUpdatingEventHandler",
				"SqlSequentialStream",
				"SqlSequentialStreamSmi",
				"System.Diagnostics.DebuggableAttribute",
				"System.Diagnostics",
				"System.Net.WebClient",
				"System",
				"System.Specialized.Protection"
			};
			return array[Renamer.rnd.Next(array.Length)];
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0001FC2C File Offset: 0x0001DE2C
		public static void Execute(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					bool flag = Renamer.CanRename(fieldDef);
					bool flag2 = flag;
					bool flag8 = flag2;
					if (flag8)
					{
						fieldDef.Name = Renamer.Random(125);
					}
				}
				foreach (EventDef eventDef in typeDef.Events)
				{
					bool flag3 = Renamer.CanRename(eventDef);
					bool flag4 = flag3;
					bool flag9 = flag4;
					if (flag9)
					{
						eventDef.Name = Renamer.Random(125);
					}
				}
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag5 = Renamer.CanRename(methodDef);
					bool flag6 = flag5;
					bool flag10 = flag6;
					if (flag10)
					{
						methodDef.Name = Renamer.Random(125);
					}
					foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef.Parameters))
					{
						parameter.Name = Renamer.Random(125);
					}
					bool hasBody = methodDef.HasBody;
					bool flag7 = hasBody;
					bool flag11 = flag7;
					if (flag11)
					{
						foreach (Local local in methodDef.Body.Variables)
						{
							local.Name = Renamer.Random(125);
						}
					}
					foreach (GenericParam genericParam in methodDef.GenericParameters)
					{
						genericParam.Name = ((char)(genericParam.Number + 1)).ToString();
					}
				}
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0001FF28 File Offset: 0x0001E128
		public static string GenerateString()
		{
			string text = "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵";
			for (int i = 0; i < 150; i++)
			{
				text += ((char)Renamer.random.Next(8000, 8500)).ToString();
			}
			return text;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0001FF80 File Offset: 0x0001E180
		public static void VirtExecute(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					bool flag = Renamer.CanRename(fieldDef);
					bool flag2 = flag;
					bool flag8 = flag2;
					if (flag8)
					{
						fieldDef.Name = Renamer.GenerateString();
					}
				}
				foreach (EventDef eventDef in typeDef.Events)
				{
					bool flag3 = Renamer.CanRename(eventDef);
					bool flag4 = flag3;
					bool flag9 = flag4;
					if (flag9)
					{
						eventDef.Name = Renamer.GenerateString();
					}
				}
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag5 = Renamer.CanRename(methodDef);
					bool flag6 = flag5;
					bool flag10 = flag6;
					if (flag10)
					{
						methodDef.Name = Renamer.GenerateString();
					}
					foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef.Parameters))
					{
						parameter.Name = Renamer.GenerateString();
					}
					bool hasBody = methodDef.HasBody;
					bool flag7 = hasBody;
					bool flag11 = flag7;
					if (flag11)
					{
						foreach (Local local in methodDef.Body.Variables)
						{
							local.Name = Renamer.GenerateString();
						}
					}
					foreach (GenericParam genericParam in methodDef.GenericParameters)
					{
						genericParam.Name = ((char)(genericParam.Number + 1)).ToString();
					}
				}
			}
		}

		// Token: 0x0400009C RID: 156
		public static Random random = new Random();

		// Token: 0x0400009D RID: 157
		public static Random rnd = new Random();
	}
}
