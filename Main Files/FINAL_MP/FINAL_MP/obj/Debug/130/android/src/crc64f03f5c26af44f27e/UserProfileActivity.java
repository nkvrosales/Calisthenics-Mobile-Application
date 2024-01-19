package crc64f03f5c26af44f27e;


public class UserProfileActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("FINAL_MP.UserProfileActivity, FINAL_MP", UserProfileActivity.class, __md_methods);
	}


	public UserProfileActivity ()
	{
		super ();
		if (getClass () == UserProfileActivity.class) {
			mono.android.TypeManager.Activate ("FINAL_MP.UserProfileActivity, FINAL_MP", "", this, new java.lang.Object[] {  });
		}
	}


	public UserProfileActivity (int p0)
	{
		super (p0);
		if (getClass () == UserProfileActivity.class) {
			mono.android.TypeManager.Activate ("FINAL_MP.UserProfileActivity, FINAL_MP", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
