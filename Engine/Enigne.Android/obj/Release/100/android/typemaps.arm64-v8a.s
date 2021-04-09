	.arch	armv8-a
	.file	"typemaps.arm64-v8a.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.word	3
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.word	253
/* java_type_count: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.arm64-v8a-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	3
	.global	map_modules
map_modules:
	/* module_uuid: f4b5bf3a-1033-4b9a-b594-5e18622c0769 */
	.byte	0x3a, 0xbf, 0xb5, 0xf4, 0x33, 0x10, 0x9a, 0x4b, 0xb5, 0x94, 0x5e, 0x18, 0x62, 0x2c, 0x07, 0x69
	/* entry_count */
	.word	6
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module0_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: MonoGame.Framework */
	.xword	.L.map_aname.0
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 9a18bf79-03aa-4d49-9852-c8f54708f6f5 */
	.byte	0x79, 0xbf, 0x18, 0x9a, 0xaa, 0x03, 0x49, 0x4d, 0x98, 0x52, 0xc8, 0xf5, 0x47, 0x08, 0xf6, 0xf5
	/* entry_count */
	.word	246
	/* duplicate_count */
	.word	46
	/* map */
	.xword	module1_managed_to_java
	/* duplicate_map */
	.xword	module1_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.xword	.L.map_aname.1
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: af56a3ae-57d1-470a-bde5-604c38412e4a */
	.byte	0xae, 0xa3, 0x56, 0xaf, 0xd1, 0x57, 0x0a, 0x47, 0xbd, 0xe5, 0x60, 0x4c, 0x38, 0x41, 0x2e, 0x4a
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module2_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Enigne.Android */
	.xword	.L.map_aname.2
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	.size	map_modules, 216
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	2
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554762
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	45
	.zero	1

	/* #1 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554763
	/* java_name */
	.ascii	"android/app/AlertDialog"
	.zero	42
	.zero	1

	/* #2 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554764
	/* java_name */
	.ascii	"android/app/AlertDialog$Builder"
	.zero	34
	.zero	1

	/* #3 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554765
	/* java_name */
	.ascii	"android/app/Application"
	.zero	42
	.zero	1

	/* #4 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554766
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	47
	.zero	1

	/* #5 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554772
	/* java_name */
	.ascii	"android/app/KeyguardManager"
	.zero	38
	.zero	1

	/* #6 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554775
	/* java_name */
	.ascii	"android/content/BroadcastReceiver"
	.zero	32
	.zero	1

	/* #7 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554784
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	31
	.zero	1

	/* #8 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554786
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	30
	.zero	1

	/* #9 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554777
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	36
	.zero	1

	/* #10 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554778
	/* java_name */
	.ascii	"android/content/ContentResolver"
	.zero	34
	.zero	1

	/* #11 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554780
	/* java_name */
	.ascii	"android/content/ContentUris"
	.zero	38
	.zero	1

	/* #12 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554773
	/* java_name */
	.ascii	"android/content/Context"
	.zero	42
	.zero	1

	/* #13 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554782
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	35
	.zero	1

	/* #14 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554795
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	34
	.zero	1

	/* #15 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554788
	/* java_name */
	.ascii	"android/content/DialogInterface$OnCancelListener"
	.zero	17
	.zero	1

	/* #16 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554791
	/* java_name */
	.ascii	"android/content/DialogInterface$OnClickListener"
	.zero	18
	.zero	1

	/* #17 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554774
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	43
	.zero	1

	/* #18 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554796
	/* java_name */
	.ascii	"android/content/IntentFilter"
	.zero	37
	.zero	1

	/* #19 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554798
	/* java_name */
	.ascii	"android/content/pm/ApplicationInfo"
	.zero	31
	.zero	1

	/* #20 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554801
	/* java_name */
	.ascii	"android/content/pm/PackageItemInfo"
	.zero	31
	.zero	1

	/* #21 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554802
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	32
	.zero	1

	/* #22 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554805
	/* java_name */
	.ascii	"android/content/res/AssetFileDescriptor"
	.zero	26
	.zero	1

	/* #23 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554806
	/* java_name */
	.ascii	"android/content/res/AssetManager"
	.zero	33
	.zero	1

	/* #24 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554807
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	32
	.zero	1

	/* #25 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554809
	/* java_name */
	.ascii	"android/content/res/Resources"
	.zero	36
	.zero	1

	/* #26 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554597
	/* java_name */
	.ascii	"android/database/CharArrayBuffer"
	.zero	33
	.zero	1

	/* #27 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554598
	/* java_name */
	.ascii	"android/database/ContentObserver"
	.zero	33
	.zero	1

	/* #28 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554604
	/* java_name */
	.ascii	"android/database/Cursor"
	.zero	42
	.zero	1

	/* #29 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554600
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	33
	.zero	1

	/* #30 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554748
	/* java_name */
	.ascii	"android/graphics/Bitmap"
	.zero	42
	.zero	1

	/* #31 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554749
	/* java_name */
	.ascii	"android/graphics/Bitmap$Config"
	.zero	35
	.zero	1

	/* #32 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554751
	/* java_name */
	.ascii	"android/graphics/BitmapFactory"
	.zero	35
	.zero	1

	/* #33 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554752
	/* java_name */
	.ascii	"android/graphics/BitmapFactory$Options"
	.zero	27
	.zero	1

	/* #34 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554750
	/* java_name */
	.ascii	"android/graphics/Canvas"
	.zero	42
	.zero	1

	/* #35 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554754
	/* java_name */
	.ascii	"android/graphics/Paint"
	.zero	43
	.zero	1

	/* #36 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554755
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	43
	.zero	1

	/* #37 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554756
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	44
	.zero	1

	/* #38 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554757
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	31
	.zero	1

	/* #39 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554759
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	22
	.zero	1

	/* #40 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554741
	/* java_name */
	.ascii	"android/hardware/Sensor"
	.zero	42
	.zero	1

	/* #41 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554743
	/* java_name */
	.ascii	"android/hardware/SensorEvent"
	.zero	37
	.zero	1

	/* #42 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554740
	/* java_name */
	.ascii	"android/hardware/SensorEventListener"
	.zero	29
	.zero	1

	/* #43 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554738
	/* java_name */
	.ascii	"android/hardware/SensorManager"
	.zero	35
	.zero	1

	/* #44 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554727
	/* java_name */
	.ascii	"android/media/AudioDeviceInfo"
	.zero	36
	.zero	1

	/* #45 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554719
	/* java_name */
	.ascii	"android/media/AudioManager"
	.zero	39
	.zero	1

	/* #46 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554731
	/* java_name */
	.ascii	"android/media/AudioRouting"
	.zero	39
	.zero	1

	/* #47 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554729
	/* java_name */
	.ascii	"android/media/AudioRouting$OnRoutingChangedListener"
	.zero	14
	.zero	1

	/* #48 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554720
	/* java_name */
	.ascii	"android/media/MediaPlayer"
	.zero	40
	.zero	1

	/* #49 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554722
	/* java_name */
	.ascii	"android/media/MediaPlayer$OnCompletionListener"
	.zero	19
	.zero	1

	/* #50 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554733
	/* java_name */
	.ascii	"android/media/VolumeAutomation"
	.zero	35
	.zero	1

	/* #51 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554736
	/* java_name */
	.ascii	"android/media/VolumeShaper"
	.zero	39
	.zero	1

	/* #52 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554737
	/* java_name */
	.ascii	"android/media/VolumeShaper$Configuration"
	.zero	25
	.zero	1

	/* #53 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554717
	/* java_name */
	.ascii	"android/net/Uri"
	.zero	50
	.zero	1

	/* #54 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554706
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	44
	.zero	1

	/* #55 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554707
	/* java_name */
	.ascii	"android/os/Build"
	.zero	49
	.zero	1

	/* #56 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554708
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	41
	.zero	1

	/* #57 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554710
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	48
	.zero	1

	/* #58 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554704
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	47
	.zero	1

	/* #59 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554713
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	48
	.zero	1

	/* #60 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554714
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	48
	.zero	1

	/* #61 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554712
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	44
	.zero	1

	/* #62 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554705
	/* java_name */
	.ascii	"android/os/Vibrator"
	.zero	46
	.zero	1

	/* #63 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554588
	/* java_name */
	.ascii	"android/provider/MediaStore"
	.zero	38
	.zero	1

	/* #64 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554589
	/* java_name */
	.ascii	"android/provider/MediaStore$Audio"
	.zero	32
	.zero	1

	/* #65 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554590
	/* java_name */
	.ascii	"android/provider/MediaStore$Audio$Media"
	.zero	26
	.zero	1

	/* #66 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554591
	/* java_name */
	.ascii	"android/provider/MediaStore$Images"
	.zero	31
	.zero	1

	/* #67 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554592
	/* java_name */
	.ascii	"android/provider/MediaStore$Images$Media"
	.zero	25
	.zero	1

	/* #68 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554593
	/* java_name */
	.ascii	"android/provider/Settings"
	.zero	40
	.zero	1

	/* #69 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554594
	/* java_name */
	.ascii	"android/provider/Settings$NameValueTable"
	.zero	25
	.zero	1

	/* #70 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554595
	/* java_name */
	.ascii	"android/provider/Settings$SettingNotFoundException"
	.zero	15
	.zero	1

	/* #71 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554596
	/* java_name */
	.ascii	"android/provider/Settings$System"
	.zero	33
	.zero	1

	/* #72 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554855
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	31
	.zero	1

	/* #73 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554699
	/* java_name */
	.ascii	"android/util/AndroidException"
	.zero	36
	.zero	1

	/* #74 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554702
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	40
	.zero	1

	/* #75 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554700
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	38
	.zero	1

	/* #76 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554698
	/* java_name */
	.ascii	"android/util/Log"
	.zero	49
	.zero	1

	/* #77 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554629
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	42
	.zero	1

	/* #78 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554631
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	33
	.zero	1

	/* #79 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554634
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	38
	.zero	1

	/* #80 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554643
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	41
	.zero	1

	/* #81 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554641
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	25
	.zero	1

	/* #82 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554637
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	33
	.zero	1

	/* #83 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554638
	/* java_name */
	.ascii	"android/view/Display"
	.zero	45
	.zero	1

	/* #84 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554612
	/* java_name */
	.ascii	"android/view/InputDevice"
	.zero	41
	.zero	1

	/* #85 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554652
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	42
	.zero	1

	/* #86 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554613
	/* java_name */
	.ascii	"android/view/KeyCharacterMap"
	.zero	37
	.zero	1

	/* #87 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554614
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	44
	.zero	1

	/* #88 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554616
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	35
	.zero	1

	/* #89 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554617
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	38
	.zero	1

	/* #90 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554619
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	30
	.zero	1

	/* #91 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554621
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	29
	.zero	1

	/* #92 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554645
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	48
	.zero	1

	/* #93 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554651
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	44
	.zero	1

	/* #94 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554647
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	21
	.zero	1

	/* #95 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554649
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	20
	.zero	1

	/* #96 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554622
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	41
	.zero	1

	/* #97 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554674
	/* java_name */
	.ascii	"android/view/OrientationEventListener"
	.zero	28
	.zero	1

	/* #98 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554677
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	41
	.zero	1

	/* #99 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554656
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	45
	.zero	1

	/* #100 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554679
	/* java_name */
	.ascii	"android/view/Surface"
	.zero	45
	.zero	1

	/* #101 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554660
	/* java_name */
	.ascii	"android/view/SurfaceHolder"
	.zero	39
	.zero	1

	/* #102 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554658
	/* java_name */
	.ascii	"android/view/SurfaceHolder$Callback"
	.zero	30
	.zero	1

	/* #103 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554682
	/* java_name */
	.ascii	"android/view/SurfaceView"
	.zero	41
	.zero	1

	/* #104 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554607
	/* java_name */
	.ascii	"android/view/View"
	.zero	48
	.zero	1

	/* #105 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554609
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	20
	.zero	1

	/* #106 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554611
	/* java_name */
	.ascii	"android/view/View$OnTouchListener"
	.zero	32
	.zero	1

	/* #107 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554685
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	43
	.zero	1

	/* #108 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554686
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	30
	.zero	1

	/* #109 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554662
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	41
	.zero	1

	/* #110 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554664
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	42
	.zero	1

	/* #111 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554623
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	36
	.zero	1

	/* #112 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554625
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	18
	.zero	1

	/* #113 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554626
	/* java_name */
	.ascii	"android/view/Window"
	.zero	46
	.zero	1

	/* #114 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554628
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	37
	.zero	1

	/* #115 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554667
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	39
	.zero	1

	/* #116 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554665
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	26
	.zero	1

	/* #117 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554691
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	20
	.zero	1

	/* #118 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554697
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	14
	.zero	1

	/* #119 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554692
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	19
	.zero	1

	/* #120 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554606
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	42
	.zero	1

	/* #121 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554605
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	42
	.zero	1

	/* #122 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554878
	/* java_name */
	.ascii	"crc64493ac3851fab1842/AndroidGameActivity"
	.zero	24
	.zero	1

	/* #123 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554884
	/* java_name */
	.ascii	"crc64493ac3851fab1842/MonoGameAndroidGameView"
	.zero	20
	.zero	1

	/* #124 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554893
	/* java_name */
	.ascii	"crc64493ac3851fab1842/OrientationListener"
	.zero	24
	.zero	1

	/* #125 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554895
	/* java_name */
	.ascii	"crc64493ac3851fab1842/ScreenReceiver"
	.zero	29
	.zero	1

	/* #126 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"crc6481457e95bb4e31f0/Activity1"
	.zero	34
	.zero	1

	/* #127 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554812
	/* java_name */
	.ascii	"crc64f0e061189adeef62/Accelerometer_SensorListener"
	.zero	15
	.zero	1

	/* #128 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554814
	/* java_name */
	.ascii	"crc64f0e061189adeef62/Compass_SensorListener"
	.zero	21
	.zero	1

	/* #129 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555001
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	48
	.zero	1

	/* #130 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554998
	/* java_name */
	.ascii	"java/io/FileDescriptor"
	.zero	43
	.zero	1

	/* #131 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554999
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	42
	.zero	1

	/* #132 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555003
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	48
	.zero	1

	/* #133 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555007
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	46
	.zero	1

	/* #134 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555004
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	46
	.zero	1

	/* #135 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555006
	/* java_name */
	.ascii	"java/io/InterruptedIOException"
	.zero	35
	.zero	1

	/* #136 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555010
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	45
	.zero	1

	/* #137 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555012
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	46
	.zero	1

	/* #138 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555009
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	45
	.zero	1

	/* #139 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555013
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	45
	.zero	1

	/* #140 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555014
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	51
	.zero	1

	/* #141 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554966
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	45
	.zero	1

	/* #142 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554968
	/* java_name */
	.ascii	"java/lang/AutoCloseable"
	.zero	42
	.zero	1

	/* #143 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554942
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	48
	.zero	1

	/* #144 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554943
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	51
	.zero	1

	/* #145 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554969
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	43
	.zero	1

	/* #146 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554944
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	46
	.zero	1

	/* #147 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554945
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	50
	.zero	1

	/* #148 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554961
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	37
	.zero	1

	/* #149 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554946
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	33
	.zero	1

	/* #150 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554972
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	46
	.zero	1

	/* #151 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554974
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	45
	.zero	1

	/* #152 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554947
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	49
	.zero	1

	/* #153 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554962
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	51
	.zero	1

	/* #154 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554964
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	50
	.zero	1

	/* #155 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554948
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	46
	.zero	1

	/* #156 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554949
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	50
	.zero	1

	/* #157 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554975
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	31
	.zero	1

	/* #158 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554976
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	34
	.zero	1

	/* #159 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554977
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	30
	.zero	1

	/* #160 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554951
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	48
	.zero	1

	/* #161 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554980
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	43
	.zero	1

	/* #162 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554952
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	51
	.zero	1

	/* #163 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554981
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	35
	.zero	1

	/* #164 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554982
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	35
	.zero	1

	/* #165 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554983
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	49
	.zero	1

	/* #166 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554953
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	49
	.zero	1

	/* #167 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554985
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	27
	.zero	1

	/* #168 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554979
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	47
	.zero	1

	/* #169 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554954
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	39
	.zero	1

	/* #170 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554986
	/* java_name */
	.ascii	"java/lang/SecurityException"
	.zero	38
	.zero	1

	/* #171 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554955
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	50
	.zero	1

	/* #172 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554956
	/* java_name */
	.ascii	"java/lang/String"
	.zero	49
	.zero	1

	/* #173 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554958
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	49
	.zero	1

	/* #174 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554960
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	46
	.zero	1

	/* #175 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554987
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	26
	.zero	1

	/* #176 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554989
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	34
	.zero	1

	/* #177 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554991
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	31
	.zero	1

	/* #178 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554993
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	29
	.zero	1

	/* #179 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554995
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	43
	.zero	1

	/* #180 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554997
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	35
	.zero	1

	/* #181 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554879
	/* java_name */
	.ascii	"java/net/ConnectException"
	.zero	40
	.zero	1

	/* #182 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554881
	/* java_name */
	.ascii	"java/net/HttpURLConnection"
	.zero	39
	.zero	1

	/* #183 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554883
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	39
	.zero	1

	/* #184 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554884
	/* java_name */
	.ascii	"java/net/ProtocolException"
	.zero	39
	.zero	1

	/* #185 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554885
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	51
	.zero	1

	/* #186 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554886
	/* java_name */
	.ascii	"java/net/Proxy$Type"
	.zero	46
	.zero	1

	/* #187 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554887
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	43
	.zero	1

	/* #188 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554889
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	43
	.zero	1

	/* #189 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554891
	/* java_name */
	.ascii	"java/net/SocketException"
	.zero	41
	.zero	1

	/* #190 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554892
	/* java_name */
	.ascii	"java/net/SocketTimeoutException"
	.zero	34
	.zero	1

	/* #191 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554894
	/* java_name */
	.ascii	"java/net/URI"
	.zero	53
	.zero	1

	/* #192 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554895
	/* java_name */
	.ascii	"java/net/URL"
	.zero	53
	.zero	1

	/* #193 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554896
	/* java_name */
	.ascii	"java/net/URLConnection"
	.zero	43
	.zero	1

	/* #194 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554893
	/* java_name */
	.ascii	"java/net/UnknownServiceException"
	.zero	33
	.zero	1

	/* #195 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554918
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	50
	.zero	1

	/* #196 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554920
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	46
	.zero	1

	/* #197 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554925
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	36
	.zero	1

	/* #198 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554927
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	40
	.zero	1

	/* #199 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554922
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	36
	.zero	1

	/* #200 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554929
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	27
	.zero	1

	/* #201 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554931
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	27
	.zero	1

	/* #202 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554933
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	28
	.zero	1

	/* #203 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554935
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	26
	.zero	1

	/* #204 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554937
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	28
	.zero	1

	/* #205 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554939
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	28
	.zero	1

	/* #206 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554940
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	15
	.zero	1

	/* #207 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554905
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	43
	.zero	1

	/* #208 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554907
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	24
	.zero	1

	/* #209 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554909
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	23
	.zero	1

	/* #210 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554904
	/* java_name */
	.ascii	"java/security/Principal"
	.zero	42
	.zero	1

	/* #211 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554910
	/* java_name */
	.ascii	"java/security/SecureRandom"
	.zero	39
	.zero	1

	/* #212 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554911
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	35
	.zero	1

	/* #213 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554913
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	28
	.zero	1

	/* #214 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554916
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	31
	.zero	1

	/* #215 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554915
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	33
	.zero	1

	/* #216 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554847
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	46
	.zero	1

	/* #217 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554836
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	45
	.zero	1

	/* #218 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554899
	/* java_name */
	.ascii	"java/util/Enumeration"
	.zero	44
	.zero	1

	/* #219 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554838
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	48
	.zero	1

	/* #220 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554856
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	48
	.zero	1

	/* #221 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554901
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	47
	.zero	1

	/* #222 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554902
	/* java_name */
	.ascii	"java/util/Random"
	.zero	49
	.zero	1

	/* #223 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554578
	/* java_name */
	.ascii	"javax/microedition/khronos/egl/EGL"
	.zero	31
	.zero	1

	/* #224 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554579
	/* java_name */
	.ascii	"javax/microedition/khronos/egl/EGL10"
	.zero	29
	.zero	1

	/* #225 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554570
	/* java_name */
	.ascii	"javax/microedition/khronos/egl/EGLConfig"
	.zero	25
	.zero	1

	/* #226 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554569
	/* java_name */
	.ascii	"javax/microedition/khronos/egl/EGLContext"
	.zero	24
	.zero	1

	/* #227 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554573
	/* java_name */
	.ascii	"javax/microedition/khronos/egl/EGLDisplay"
	.zero	24
	.zero	1

	/* #228 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554575
	/* java_name */
	.ascii	"javax/microedition/khronos/egl/EGLSurface"
	.zero	24
	.zero	1

	/* #229 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554548
	/* java_name */
	.ascii	"javax/net/SocketFactory"
	.zero	42
	.zero	1

	/* #230 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554553
	/* java_name */
	.ascii	"javax/net/ssl/HostnameVerifier"
	.zero	35
	.zero	1

	/* #231 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554550
	/* java_name */
	.ascii	"javax/net/ssl/HttpsURLConnection"
	.zero	33
	.zero	1

	/* #232 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554555
	/* java_name */
	.ascii	"javax/net/ssl/KeyManager"
	.zero	41
	.zero	1

	/* #233 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554564
	/* java_name */
	.ascii	"javax/net/ssl/KeyManagerFactory"
	.zero	34
	.zero	1

	/* #234 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554565
	/* java_name */
	.ascii	"javax/net/ssl/SSLContext"
	.zero	41
	.zero	1

	/* #235 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554557
	/* java_name */
	.ascii	"javax/net/ssl/SSLSession"
	.zero	41
	.zero	1

	/* #236 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554559
	/* java_name */
	.ascii	"javax/net/ssl/SSLSessionContext"
	.zero	34
	.zero	1

	/* #237 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554566
	/* java_name */
	.ascii	"javax/net/ssl/SSLSocketFactory"
	.zero	35
	.zero	1

	/* #238 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554561
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	39
	.zero	1

	/* #239 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554568
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	32
	.zero	1

	/* #240 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554563
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	35
	.zero	1

	/* #241 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554544
	/* java_name */
	.ascii	"javax/security/cert/Certificate"
	.zero	34
	.zero	1

	/* #242 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554546
	/* java_name */
	.ascii	"javax/security/cert/X509Certificate"
	.zero	30
	.zero	1

	/* #243 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33555037
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	41
	.zero	1

	/* #244 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554789
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnCancelListenerImplementor"
	.zero	1
	.zero	1

	/* #245 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554793
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnClickListenerImplementor"
	.zero	2
	.zero	1

	/* #246 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554723
	/* java_name */
	.ascii	"mono/android/media/MediaPlayer_OnCompletionListenerImplementor"
	.zero	3
	.zero	1

	/* #247 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554832
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	26
	.zero	1

	/* #248 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	35
	.zero	1

	/* #249 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554853
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	34
	.zero	1

	/* #250 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554871
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	25
	.zero	1

	/* #251 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554959
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	31
	.zero	1

	/* #252 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554543
	/* java_name */
	.ascii	"xamarin/android/net/OldAndroidSSLSocketFactory"
	.zero	19
	.zero	1

	.size	map_java, 18722
/* Java to managed map: END */


/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.word	66
/* java_name_width: END */
