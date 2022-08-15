/*************************************************************************************************************
* Programa: Binary.cs                                                                                        *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase                                                               *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/

/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 */

using System;
using System.Drawing;
using System.IO;

namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        public bool InsertBinaryIntoCell(byte[] binaryData, string sqlQuery, string argumentNameWithBinaryData, params XParameter[] args)
        {
            ClearError();

            var parameters = new XParameter[args.Length + 1];
            for (var i = 0; i < args.Length; i++)
            {
                parameters[i] = args[i];
            }
            parameters[args.Length] = new XParameter(argumentNameWithBinaryData, binaryData);

            try
            {
                return Update(sqlQuery, parameters) >= (int)XResult.ChangesApplied;
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return false;
            }
        }

        public bool InsertFileIntoCell(string fileFullPath, string sqlQuery, string argumentNameWithFilePath, params XParameter[] args)
        {
            ClearError();

            try
            {
                var fileStream = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);
                var fileBytes = new byte[fileStream.Length];
                fileStream.Read(fileBytes, 0, (int)fileStream.Length);
                fileStream.Close();

                return InsertBinaryIntoCell(fileBytes, sqlQuery, argumentNameWithFilePath, args);
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return false;
            }
        }

        public Image SelectBinaryAsImage(string sqlQuery, params XParameter[] args)
        {
            ClearError();

            try
            {
                var fileBytes = SelectCellAs<byte[]>(sqlQuery, args);
                var memStream = new MemoryStream(fileBytes);
                var image = Image.FromStream(memStream);
                return image;
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return null;
            }
        }

        public bool SelectBinaryAndSave(string outputFileName, string sqlQuery, params XParameter[] args)
        {
            ClearError();

            try
            {
                var fileBytes = SelectCellAs<byte[]>(sqlQuery, args);
                var newFileStream = new FileStream(outputFileName, FileMode.CreateNew);
                newFileStream.Write(fileBytes, 0, fileBytes.Length);
                newFileStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return false;
            }
        }
    }
}
