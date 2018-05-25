using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Windows.Forms;

namespace MyUtilities
{

    public static class FileSerializer
    {
        public static void Serialize( string filename, object objectToSerialize )
        {
            if (objectToSerialize == null)
                throw new ArgumentNullException("objectToSerialize cannot be null");
            Stream stream = null;
            try
            {
                stream = File.Open(filename, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public static T Deserialize<T>( string filename )
        {
            T objectToSerialize = default(T);
            Stream stream = null;
            try
            {
                stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (T)bFormatter.Deserialize(stream);
            }
            catch (Exception err)
            {
                MessageBox.Show("The application failed to retrieve the inventory - " + err.Message);               
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return objectToSerialize;
        }
    }

}
